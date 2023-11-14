using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FedoreevOrganization
{
    public class users
    {
        public int id { get; set; }
        public string name { get; set; }
        public string password { get; set; }
        public string permissions { get; set; }
        public users(int id, string name, string password, string permissions)
        {
            this.id = id;
            this.name = name;
            this.password = password;
            this.permissions = permissions;
        }
    }
    public class products
    {
        public int id { get; set; }
        public string name { get; set; }
        public double price { get; set; }
        public int amount { get; set; }
        public products(int id, string name, double price, int amount)
        {
            this.id =id;
            this.name =name;
            this.price =price;
            this.amount =amount;
        }
    }
    public class clients
    {
        public int id { get; set; }
        public string name { get; set; }
        public string phone_number { get; set; }
        public string address { get; set; }
        public clients(int id, string name, string phone_number, string address)
        {
            this.id = id;
            this.name = name;
            this.phone_number = phone_number;
            this.address = address;
        }
    }
    public class contract
    {
        public int id { get; set; }
        public int id_client { get; set; }
        public DateTime date { get; set; }
        public bool pre_pay{ get; set; }
        public contract(int id, int id_client, DateTime date, bool pre_pay)
        {
            this.id = id;
            this.id_client = id_client;
            this.date = date;
            this.pre_pay = pre_pay;
        }
    }
    public class contracts_bond
    {
        public int id { get; set; }
        public int id_contract { get; set; }
        public int id_product { get; set; }
        public int amount { get; set; }
        public contracts_bond(int id, int id_contract, int id_product, int amount)
        {
            this.id =id;
            this.id_contract= id_contract;
            this.id_product = id_product;
            this.amount = amount;
        }
    }
    public class delivery 
    { 
        public int id { get; set; }
        public int id_contract { get; set; }
        public int id_product { get; set; }
        public int amount { get; set; }
        public DateTime date { get; set; }
        public delivery(int id, int id_contract, int id_product, int amount, DateTime date)
        {
            this.id = id;
            this.id_contract = id_contract;
            this.id_product=id_product;
            this.amount = amount;
            this.date = date;
        }
    }
    public class reportProducts
    {
        public string name { get; set; }
        public int numOfContracted { get; set; }
        public int numOfPayed { get; set; }
        public reportProducts(string name, int numOfContracted, int numOfPayed)
        {
            this.name = name;
            this.numOfContracted = numOfContracted;
            this.numOfPayed = numOfPayed;
        }
        public reportProducts() { }
    }
    public class reportClients
    {
        public string clientName { get; set; }
        public string productName { get; set; }
        public int numOfDeliverys { get; set; }
        public int numOfPayedButNotDelivery { get; set; }
        public reportClients(string clientName, string productName, int numOfDeliverys, int numOfPayedButNotDelivery)
        {
            this.clientName = clientName;
            this.productName = productName;
            this.numOfDeliverys = numOfDeliverys;
            this.numOfPayedButNotDelivery = numOfPayedButNotDelivery;
        }
        public reportClients() { }
    }
    public class reportContract
    {
        public string productName { get; set; }
        public int amount { get; set; }
        public double summ { get; set; }
        public reportContract(string productName, int amount, double summ)
        {
            this.productName = productName;
            this.amount = amount;
            this.summ = summ;
        }
    }
    public class clientsStruct
    {
        public int id_product { get; set; }
        public int amount { get; set; }
        public clientsStruct(int id_product, int amount)
        {
            this.id_product = id_product;
            this.amount = amount;
        }
    }
    public class contractsInfo
    {
        public int id_client { get; set; }
        public int id_contract { get; set; }
        public bool pre_pay { get; set; }
        public contractsInfo(int id_contract, int id_client, bool pre_pay)
        {
            this.id_client = id_client;
            this.id_contract = id_contract;
            this.pre_pay = pre_pay;
        }
    }
}
