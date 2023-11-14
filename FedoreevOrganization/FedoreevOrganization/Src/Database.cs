using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace FedoreevOrganization
{
    internal class Database
    {
        public static string Host = "localhost";
        public static string User = "postgres";
        public static string DBname = "postgres";
        public static string Password = "123";
        public static string Port = "5432";

        public static string connString =
            String.Format("Server={0};Username={1};Database={2};Port={3};Password={4};SSLMode=Prefer",
            Host,
            User,
            DBname,
            Port,
            Password);
        // **** AUTHORIZATION **** // 
        public static string authorization(string login, string password)
        {
            using (var conn = new NpgsqlConnection(connString))
            {
                conn.Open();
                using (var command = new NpgsqlCommand("SELECT * FROM users WHERE name = '" + login + "' ", conn))
                {
                    var reader = command.ExecuteReader();
                    while (reader.Read()) 
                    {
                        if(password.GetHashCode().ToString() == reader.GetString(2)) { return reader.GetString(3); }
                    }
                    reader.Close();
                }
                conn.Close();
            }
            return null;
        }
        // **** SELECT **** // 
        public static List<users> dbGetListUsers()
        {
            List<users> usersList = new List<users>();
            using (var conn = new NpgsqlConnection(connString))
            {
                conn.Open();
                using (var command = new NpgsqlCommand("SELECT * FROM users", conn))
                {
                    var reader = command.ExecuteReader();
                    while (reader.Read()) { usersList.Add(new users(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3))); }
                    reader.Close();
                }
                conn.Close();
            }
            return usersList;
        }
        public static List<products> dbGetListProducts()
        {
            List<products> productsList = new List<products>();
            using (var conn = new NpgsqlConnection(connString))
            {
                conn.Open();
                using (var command = new NpgsqlCommand("SELECT * FROM products", conn))
                {
                    var reader = command.ExecuteReader();
                    while (reader.Read()) { productsList.Add(new products(reader.GetInt32(0), reader.GetString(1), reader.GetDouble(2), reader.GetInt32(3))); }
                    reader.Close();
                }
                conn.Close();
            }
            return productsList;
        }
        public static List<clients> dbGetListClients()
        {
            List<clients> clientsList = new List<clients>();
            using (var conn = new NpgsqlConnection(connString))
            {
                conn.Open();
                using (var command = new NpgsqlCommand("SELECT * FROM clients", conn))
                {
                    var reader = command.ExecuteReader();
                    while (reader.Read()) { clientsList.Add(new clients(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3))); }
                    reader.Close();
                }
                conn.Close();
            }
            return clientsList;
        }
        public static List<contract> dbGetListContract()
        {
            List<contract> contractList = new List<contract>();
            using (var conn = new NpgsqlConnection(connString))
            {
                conn.Open();
                using (var command = new NpgsqlCommand("SELECT * FROM contract", conn))
                {
                    var reader = command.ExecuteReader();
                    while (reader.Read()) { contractList.Add(new contract(reader.GetInt32(0), reader.GetInt32(1), reader.GetDateTime(2), reader.GetBoolean(3))); }
                    reader.Close();
                }
                conn.Close();
            }
            return contractList;
        }
        public static List<contracts_bond> dbGetListContractsBond()
        {
            List<contracts_bond> contracts_bondList = new List<contracts_bond>();
            using (var conn = new NpgsqlConnection(connString))
            {
                conn.Open();
                using (var command = new NpgsqlCommand("SELECT * FROM contracts_bond", conn))
                {
                    var reader = command.ExecuteReader();
                    while (reader.Read()) { contracts_bondList.Add(new contracts_bond(reader.GetInt32(0), reader.GetInt32(1), reader.GetInt32(2), reader.GetInt32(3))); }
                    reader.Close();
                }
                conn.Close();
            }
            return contracts_bondList;
        }
        public static List<delivery> dbGetListDelivery()
        {
            List<delivery> deliveryList = new List<delivery>();
            using (var conn = new NpgsqlConnection(connString))
            {
                conn.Open();
                using (var command = new NpgsqlCommand("SELECT * FROM delivery", conn))
                {
                    var reader = command.ExecuteReader();
                    while (reader.Read()) { deliveryList.Add(new delivery(reader.GetInt32(0), reader.GetInt32(1), reader.GetInt32(2), reader.GetInt32(3), reader.GetDateTime(4))); }
                    reader.Close();
                }
                conn.Close();
            }
            return deliveryList;
        }
        public static int dbGetLastContractID()
        {
            int lastID = 0;
            using (var conn = new NpgsqlConnection(connString))
            {
                conn.Open();
                using (var command = new NpgsqlCommand("SELECT max(id) FROM contract", conn))
                {
                    var reader = command.ExecuteReader();
                    while (reader.Read()) { lastID = reader.GetInt32(0); }
                    reader.Close();
                }
                conn.Close();
            }
            return lastID;
        }

        // **** INSERT **** // 
        public static void dbInsertUsers(string name, string password, string permissions)
        {
            using (var conn = new NpgsqlConnection(connString))
            {
                conn.Open();
                using (var command = new NpgsqlCommand("INSERT INTO users (name, password, permissions) " +
                    "VALUES ('" + name + "', '" + password.GetHashCode().ToString() + "', '" + permissions + "')", conn))
                {
                    command.ExecuteReader();
                }
                conn.Close();
            }
        }
        public static void dbInsertProducts(string name, double price, int amount)
        {
            using (var conn = new NpgsqlConnection(connString))
            {
                conn.Open();
                using (var command = new NpgsqlCommand("INSERT INTO products (name, price, amount) " +
                    "VALUES ('" + name + "', " + price + ", " + amount + ")", conn))
                {
                    command.ExecuteReader();
                }
                conn.Close();
            }
        }
        public static void dbInsertClients(string name, string phone_number, string address)
        {
            using (var conn = new NpgsqlConnection(connString))
            {
                conn.Open();
                using (var command = new NpgsqlCommand("INSERT INTO clients (name, phone_number, address) " +
                    "VALUES ('" + name + "', '" + phone_number + "', '" + address + "')", conn))
                {
                    command.ExecuteReader();
                }
                conn.Close();
            }
        }
        public static void dbInsertContract(int id_client, string date, bool pre_pay)
        {
            using (var conn = new NpgsqlConnection(connString))
            {
                conn.Open();
                using (var command = new NpgsqlCommand("INSERT INTO contract (id_client, date, pre_pay) " +
                    "VALUES (" + id_client + ", '" + date + "', '" + pre_pay + "')", conn))
                {
                    command.ExecuteReader();
                }
                conn.Close();
            }
        }
        public static void dbInsertContractsBond(int id_contract, int id_product, int amount)
        {
            using (var conn = new NpgsqlConnection(connString))
            {
                conn.Open();
                using (var command = new NpgsqlCommand("INSERT INTO contracts_bond (id_contract, id_product, amount) " +
                    "VALUES (" + id_contract + ", " + id_product + ", " + amount + ")", conn))
                {
                    command.ExecuteReader();
                }
                conn.Close();
            }
        }
        public static void dbInsertDelivery(int id_contract, int id_product, int amount, string date)
        {
            using (var conn = new NpgsqlConnection(connString))
            {
                conn.Open();
                using (var command = new NpgsqlCommand("INSERT INTO delivery (id_contract, id_product, amount, date) " +
                    "VALUES (" + id_contract + ", " + id_product + ", " + amount + ", '" + date + "')", conn))
                {
                    command.ExecuteReader();
                }
                conn.Close();
            }
        }
        // **** UPDATE **** // 
        public static void dbUpdateUsers(string id, string name, string password, string permissions)
        {
            using (var conn = new NpgsqlConnection(connString))
            {
                conn.Open();
                using (var command = new NpgsqlCommand("UPDATE users " +
                                                        "SET name = '" + name + "', password =  '" + password.GetHashCode().ToString() + "', permissions = '" + permissions + "' " +
                                                        "WHERE id = " + id, conn))
                {
                    command.ExecuteReader();
                }
                conn.Close();
            }
        }
        public static void dbUpdateProducts(string id, string name, double price, int amount)
        {
            using (var conn = new NpgsqlConnection(connString))
            {
                conn.Open();
                using (var command = new NpgsqlCommand("UPDATE products " +
                                                        "SET name = '" + name + "', amount =  " + amount + ", price = " + price + " " +
                                                        "WHERE id = " + id, conn))
                {
                    command.ExecuteReader();
                }
                conn.Close();
            }
        }
        public static void dbUpdateClients(string id, string name, string phone_number, string address)
        {
            using (var conn = new NpgsqlConnection(connString))
            {
                conn.Open();
                using (var command = new NpgsqlCommand("UPDATE clients " +
                                                        "SET name = '" + name + "', phone_number =  '" + phone_number + "', address = '" + address + "' " +
                                                        "WHERE id = " + id, conn))
                {
                    command.ExecuteReader();
                }
                conn.Close();
            }
        }
        public static void dbUpdateContract(string id, int id_client, string date, bool pre_pay)
        {
            using (var conn = new NpgsqlConnection(connString))
            {
                conn.Open();
                using (var command = new NpgsqlCommand("UPDATE contract " +
                                                        "SET id_client = " + id_client + ", date =  '" + date + "', pre_pay = " + pre_pay + " " +
                                                        "WHERE id = " + id, conn))
                {
                    command.ExecuteReader();
                }
                conn.Close();
            }
        }
        public static void dbUpdateContractsBond(string id, int id_contract, int id_product, int amount)
        {
            using (var conn = new NpgsqlConnection(connString))
            {
                conn.Open();
                using (var command = new NpgsqlCommand("UPDATE contracts_bond " +
                                                        "SET id_contract = " + id_contract + ", id_product =  " + id_product + ", amount = " + amount + " " +
                                                        "WHERE id = " + id, conn))
                {
                    command.ExecuteReader();
                }
                conn.Close();
            }
        }
        public static void dbUpdateDelivery(string id, int id_contract, int id_product, int amount, string date)
        {
            using (var conn = new NpgsqlConnection(connString))
            {
                conn.Open();
                using (var command = new NpgsqlCommand("UPDATE delivery " +
                                                        "SET id_contract = " + id_contract + ", id_product =  " + id_product + ", amount = " + amount + ", date = '" + date + "' " +
                                                        "WHERE id = " + id, conn))
                {
                    command.ExecuteReader();
                }
                conn.Close();
            }
        }
        // **** DELETE **** // 
        public static void dbDeleteUsers(string id)
        {
            using (var conn = new NpgsqlConnection(connString))
            {
                conn.Open();
                using (var command = new NpgsqlCommand("DELETE FROM users " +
                                                        "WHERE id = " + id, conn))
                {
                    command.ExecuteReader();
                }
                conn.Close();
            }
        }
        public static void dbDeleteProducts(string id)
        {
            using (var conn = new NpgsqlConnection(connString))
            {
                conn.Open();
                using (var command = new NpgsqlCommand("DELETE FROM products " +
                                                        "WHERE id = " + id, conn))
                {
                    command.ExecuteReader();
                }
                conn.Close();
            }
        }
        public static void dbDeleteClients(string id)
        {
            using (var conn = new NpgsqlConnection(connString))
            {
                conn.Open();
                using (var command = new NpgsqlCommand("DELETE FROM clients " +
                                                        "WHERE id = " + id, conn))
                {
                    command.ExecuteReader();
                }
                conn.Close();
            }
        }
        public static void dbDeleteContract(string id)
        {
            using (var conn = new NpgsqlConnection(connString))
            {
                conn.Open();
                using (var command = new NpgsqlCommand("DELETE FROM contract " +
                                                        "WHERE id = " + id, conn))
                {
                    command.ExecuteReader();
                }
                conn.Close();
            }
        }
        public static void dbDeleteContractsBond(string id)
        {
            using (var conn = new NpgsqlConnection(connString))
            {
                conn.Open();
                using (var command = new NpgsqlCommand("DELETE FROM contracts_bond " +
                                                        "WHERE id = " + id, conn))
                {
                    command.ExecuteReader();
                }
                conn.Close();
            }
        }
        public static void dbDeleteDelivery(string id)
        {
            using (var conn = new NpgsqlConnection(connString))
            {
                conn.Open();
                using (var command = new NpgsqlCommand("DELETE FROM delivery " +
                                                        "WHERE id = " + id, conn))
                {
                    command.ExecuteReader();
                }
                conn.Close();
            }
        }
        // **** REPORTS **** // 
        public static List<reportProducts> dbGetReportProducts(List<string> productsID, DateTime dateFrom, DateTime dateTo)
        {
            List<reportProducts> report = new List<reportProducts>();
            using (var conn = new NpgsqlConnection(connString))
            {
                foreach (var product in productsID)
                {
                    conn.Open();
                    using (var command = new NpgsqlCommand("SELECT products.name, contracts_bond.amount, contract.pre_pay " +
                                                        "FROM contract, contracts_bond, products " +
                                                        "WHERE DATE(contract.date) > '" + dateFrom.Year + "-" + dateFrom.Month + "-" + dateFrom.Day + "' " +
                                                        "AND DATE(contract.date) < '" + dateTo.Year + "-" + dateTo.Month + "-" + dateTo.Day + "' " +
                                                        "AND contracts_bond.id_contract = contract.id " +
                                                        "AND contracts_bond.id_product = " + product + 
                                                        "AND products.id = " + product, conn))
                    {
                        var reader = command.ExecuteReader();

                        reportProducts some = new reportProducts();
                        // бегаем по циклу одного продукта из списка и суммируем все закантрактованные и все оплаченные товары
                        while (reader.Read()) 
                        {
                            some.name = reader.GetString(0);
                            if(reader.GetBoolean(2))
                                some.numOfPayed += reader.GetInt32(1);
                            else 
                                some.numOfContracted += reader.GetInt32(1);
                        }
                        reader.Close();
                        // здесь заканчивается обработка первого товара и мы добавляем его в список
                        report.Add(new reportProducts(some.name, some.numOfContracted, some.numOfPayed));
                    }
                    conn.Close();
                }
            }
            return report;
        }
        public static List<reportClients> dbGetReportClients(List<string> clientsID, DateTime dateFrom, DateTime dateTo)
        {
            List<reportClients> report = new List<reportClients>();
            
            using (var conn = new NpgsqlConnection(connString))
            {
                foreach (var client in clientsID)
                {
                    List<contractsInfo> contractsInfo = new List<contractsInfo>();
                    conn.Open();
                    using (var command = new NpgsqlCommand("SELECT id, pre_pay " +
                                                            "FROM contract " +
                                                            "WHERE id_client = " + client + " " +
                                                            "AND DATE(contract.date) > '" + dateFrom.Year + "-" + dateFrom.Month + "-" + dateFrom.Day + "' " +
                                                            "AND DATE(contract.date) < '" + dateTo.Year + "-" + dateTo.Month + "-" + dateTo.Day + "' ", conn))
                    {
                        var reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            // сохраняем инфу из бд для дальнейшей с ней работы
                            contractsInfo.Add(new contractsInfo(reader.GetInt32(0), reader.GetInt32(1), reader.GetBoolean(2)));
                            
                        }
                        reader.Close();
                    }
                    conn.Close();

                    foreach (var contract in contractsInfo)
                    {
                        // работаем поочерёдно с каждым контрактом
                        int id_client = contract.id_client;
                        int id_contract = contract.id_contract;
                        bool prePay = contract.pre_pay;
                        List<clientsStruct> contractsBondList = new List<clientsStruct>();
                        List<clientsStruct> deliveryList = new List<clientsStruct>();

                        conn.Open();
                            using (var command2 = new NpgsqlCommand("SELECT id_product, amount " +
                                                                    "FROM contracts_bond " +
                                                                    "WHERE id_contract = " + id_contract, conn))
                            {
                                var reader2 = command2.ExecuteReader();
                                while (reader2.Read())
                                {
                                    // считываем все ОБЯЗАТЕЛЬСТВА по текущему контракту
                                    contractsBondList.Add(new clientsStruct(reader2.GetInt32(0), reader2.GetInt32(1)));
                                }
                                
                            }
                        conn.Close();
                        conn.Open();
                            using (var command2 = new NpgsqlCommand("SELECT id_product, amount " +
                                                                    "FROM delivery " +
                                                                    "WHERE id_contract = " + id_contract, conn))
                            {
                                var reader2 = command2.ExecuteReader();
                                while (reader2.Read())
                                {
                                    // считываем все ДОСТАВКИ по текущему контракту
                                    deliveryList.Add(new clientsStruct(reader2.GetInt32(0), reader2.GetInt32(1)));
                                }
                            }
                            conn.Close();
                        // обработка. подсчёт доставок и обязательств по каждому продукту по данному контракту

                        // бегаем по каждому продукту из обязательств по контракту и проверяем на условия
                        foreach (var contractsBond in contractsBondList)
                        {
                            int numOfDeliverys = 0;
                            int numOfPayedButNotDelivery = 0;

                            // проверяем на существование доставки по этому продукту
                            foreach (var deliverys in deliveryList)
                                if (deliverys.id_product == contractsBond.id_product)
                                    numOfDeliverys += deliverys.amount;

                            // если была предоплата, то должны отправить все оставшиеся товары по данному контракту
                            if (prePay)
                                numOfPayedButNotDelivery = contractsBond.amount - numOfDeliverys;

                            // поиск названия продукта 
                            string productName = "";
                            conn.Open();
                                using (var command2 = new NpgsqlCommand("SELECT name " +
                                                                        "FROM products " +
                                                                        "WHERE id = " + contractsBond.id_product, conn))
                                {
                                    var reader2 = command2.ExecuteReader();
                                    while (reader2.Read())
                                        productName = reader2.GetString(0);
                                    
                                }
                            conn.Close();

                            conn.Open();
                            string clientName = "";
                            using (var command2 = new NpgsqlCommand("SELECT name " +
                                                                    "FROM clients " +
                                                                    "WHERE id = " + id_client, conn))
                            {
                                var reader2 = command2.ExecuteReader();
                                while (reader2.Read())
                                    clientName = reader2.GetString(0);

                            }
                            conn.Close();
                            report.Add(new reportClients(clientName, productName, numOfDeliverys, numOfPayedButNotDelivery));
                        }
                    }
                }
            }
            return report;
        }
        public static List<reportContract> dbGetReportContract(int contractID)
        {
            List<reportContract> report = new List<reportContract>();
            List<contracts_bond> contracts_bondList = new List<contracts_bond>();

            using (var conn = new NpgsqlConnection(connString))
            {
                conn.Open();
                using (var command = new NpgsqlCommand("SELECT * FROM contracts_bond WHERE id_contract = " + contractID, conn))
                {
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        contracts_bondList.Add(new contracts_bond(reader.GetInt32(0), reader.GetInt32(1), reader.GetInt32(2), reader.GetInt32(3)));
                    }
                }
                conn.Close();

                foreach(var contract in contracts_bondList)
                {
                    conn.Open();
                    using (var command = new NpgsqlCommand("SELECT name, price FROM products WHERE id = " + contract.id_product, conn))
                    {
                        var reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            report.Add(new reportContract(reader.GetString(0), contract.amount, Convert.ToDouble(contract.amount) * reader.GetDouble(1)));
                        }
                    }
                    conn.Close();
                }
            }
            return report;
        }

    }
}
