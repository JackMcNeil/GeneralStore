namespace GeneralStore.MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedaviewbagmodels : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Transactions", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.Transactions", "ProductId", "dbo.Products");
            DropIndex("dbo.Transactions", new[] { "ProductId" });
            DropIndex("dbo.Transactions", new[] { "CustomerId" });
            AddColumn("dbo.Customers", "Transaction_TransactionId", c => c.Int());
            AddColumn("dbo.Products", "Transaction_TransactionId", c => c.Int());
            CreateIndex("dbo.Customers", "Transaction_TransactionId");
            CreateIndex("dbo.Products", "Transaction_TransactionId");
            AddForeignKey("dbo.Customers", "Transaction_TransactionId", "dbo.Transactions", "TransactionId");
            AddForeignKey("dbo.Products", "Transaction_TransactionId", "dbo.Transactions", "TransactionId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "Transaction_TransactionId", "dbo.Transactions");
            DropForeignKey("dbo.Customers", "Transaction_TransactionId", "dbo.Transactions");
            DropIndex("dbo.Products", new[] { "Transaction_TransactionId" });
            DropIndex("dbo.Customers", new[] { "Transaction_TransactionId" });
            DropColumn("dbo.Products", "Transaction_TransactionId");
            DropColumn("dbo.Customers", "Transaction_TransactionId");
            CreateIndex("dbo.Transactions", "CustomerId");
            CreateIndex("dbo.Transactions", "ProductId");
            AddForeignKey("dbo.Transactions", "ProductId", "dbo.Products", "ProductId", cascadeDelete: true);
            AddForeignKey("dbo.Transactions", "CustomerId", "dbo.Customers", "CustomerId", cascadeDelete: true);
        }
    }
}
