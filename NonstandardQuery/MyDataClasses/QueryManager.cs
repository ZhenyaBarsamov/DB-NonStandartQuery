using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NonstandardQuery.MyDataClasses {
    class QueryManager {
        //Поле с БД
        DataBaseInfo DBInfo { get; set; }
        //Констуктор
        public QueryManager(DataBaseInfo dbInfo) {
            DBInfo = dbInfo;
        }

        //Метод получения множества условий соединения таблиц
        //и множества всех задейстованных таблиц
        public void ConnectTables(List<string> selectingTables, HashSet<string> necessaryTables, HashSet<string> necessaryConnectionConditions) {
            var relationMatrix = DBInfo.Relations;
            List<string> unconnectedTables = new List<string>(selectingTables);
            while (unconnectedTables.Count != 0) {
                //Найдём самый длиный путь между ещё несоединёнными таблицами
                List<string> maxTablesPath = new List<string>();
                List<string> maxConnectionConditions = new List<string>();
                //Если осталась одна таблица - добавляем её в путь, и выходим
                if (unconnectedTables.Count == 1)
                    maxTablesPath.Add(unconnectedTables[0]);
                //Если таблиц несколько, то найдём самый длиный
                for (int i = 0; i < unconnectedTables.Count; i++) {
                    for (int j = i + 1; j < unconnectedTables.Count; j++) {
                        List<string> tablesPath = new List<string>();
                        List<string> connectionConditions = new List<string>();
                        relationMatrix.GetTwoTablesConnectionPath(unconnectedTables[i], unconnectedTables[j], tablesPath, connectionConditions);
                        if (tablesPath.Count >= maxTablesPath.Count) {
                            maxTablesPath = tablesPath;
                            maxConnectionConditions = connectionConditions;
                        }
                    }
                }
                //Отмечаем таблички, которые были использованы в этом пути, и помечаем как использованные
                foreach (var tableName in maxTablesPath) {
                    necessaryTables.Add(tableName);
                    unconnectedTables.Remove(tableName);
                }
                //Добавляем нужные связи
                foreach (var connectionCondition in maxConnectionConditions)
                    necessaryConnectionConditions.Add(connectionCondition);
            }
        }


        //Метод получения строки, содержащей SELECT-часть запроса
        private string GetSELECTString(List<ColumnInfo> selectingColumns, bool isForDisplay) {
            string selectStr = "";
            var collectionLength = selectingColumns.Count;
            for (int i = 0; i < collectionLength; i++) {
                selectStr += selectingColumns[i].QualifiedColumnName;
                //Добавляем Алиас, если запрос для выполнения
                if (!isForDisplay)
                    selectStr += $" AS \"{selectingColumns[i].Table.TableName + "." + selectingColumns[i].ColumnName}\"";
                if (i != collectionLength - 1)
                    selectStr += ", ";
            }
            return selectStr;
        }

        //Метод получения строки, содержащей FROM-часть запроса
        private string GetFROMString(List<string> necessaryTablesNames) {
            var fromStr = "";
            var collectionLength = necessaryTablesNames.Count;
            for (int i = 0; i < collectionLength; i++) {
                fromStr += DBInfo.TablesDict[necessaryTablesNames[i]].QualifiedTableName;
                if (i != collectionLength - 1)
                    fromStr += ", ";
            }
            return fromStr;
        }

        //Метод получения строки, содержащей WHERE-часть запроса
        private string GetWHEREString(List<Condition> conditions, List<string> connectionConditions, bool isForDisplay) {
            string whereStr = "";
            var collectionLength = conditions.Count;
            //Формируем строку основных условий
            if (collectionLength != 0) {
                whereStr += "(";
                for (int i = 0; i < collectionLength; i++) {
                    //Если строка для отображения - подставляем значение
                    if (isForDisplay)
                        whereStr += conditions[i].ConditionString;
                    else
                        //Имя параметра = параметр для колонки + порядковый номер условия
                        whereStr += conditions[i].ParametrizedConditionString + i.ToString();
                    if (i != collectionLength - 1)
                        whereStr += $" {conditions[i].GetSqlLigament()} ";
                }
                whereStr += ")";
            }
            //Формируем строку условий соединения
            collectionLength = connectionConditions.Count;
            if (collectionLength != 0) {
                if (conditions.Count != 0)
                    whereStr += " AND ";
                whereStr += "(";
                for (int i = 0; i < collectionLength; i++) {
                    whereStr += connectionConditions[i];
                    if (i != collectionLength - 1)
                        whereStr += " AND ";
                }
                whereStr += ")";
            }
            return whereStr;
        }

        //Метод получения строки, содержащей ORDERBY-часть запроса
        private string GetORDERBYString(List<OrderedColumn> orders) {
            string orderByStr = "";
            var collectionLength = orders.Count;
            for (int i = 0; i < collectionLength; i++) {
                orderByStr += orders[i].OrderedColumnStr;
                if (i != collectionLength - 1)
                    orderByStr += ", ";
            }
            return orderByStr;
        }

        //Метод получения полного текста запроса
        public string GetQueryText(List<ColumnInfo> selectingColumns, List<Condition> conditions, List<OrderedColumn> orders, bool isForDisplay) {
            string queryText;
            string selectStr, fromStr, whereStr, orderByStr;
            //Получаем список всех запрошенных таблиц (в т.ч. с условиями выборки)
            HashSet<string> tablesSet = new HashSet<string>();
            foreach (var column in selectingColumns)
                tablesSet.Add(column.Table.TableName);
            foreach (var condition in conditions)
                tablesSet.Add(condition.Column.Table.TableName);
            List<string> selectingTables = new List<string>(tablesSet);
            //Получаем список необходимых для запроса таблиц и условий связи
            HashSet<string> necessaryTables = new HashSet<string>();
            HashSet<string> necessaryConnectionConditions = new HashSet<string>();
            ConnectTables(selectingTables, necessaryTables, necessaryConnectionConditions);
            //Формируем SELECT-строку
            selectStr = GetSELECTString(selectingColumns, isForDisplay);
            //Формируем FROM-строку
            fromStr = GetFROMString(necessaryTables.ToList());
            //Формируем WHERE-строку
            whereStr = GetWHEREString(conditions, necessaryConnectionConditions.ToList(), isForDisplay);
            //Формируем ORDER BY-строку
            orderByStr = GetORDERBYString(orders);
            //Формируем основной текст запроса
            queryText = $@"
SELECT {selectStr}
FROM {fromStr}";
            //Добавляем при необходимости строку WHERE
            if (necessaryConnectionConditions.Count != 0 || conditions.Count != 0)
                queryText += "\n" + $"WHERE {whereStr}";
            //Добавляем при необходимости строку ORDER BY
            if (orders.Count != 0)
                queryText += "\n" + $"ORDER BY {orderByStr}";
            //Возвращаем текст запроса
            return queryText;
        }
    }
}
