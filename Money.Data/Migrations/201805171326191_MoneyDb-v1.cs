namespace Money.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MoneyDbv1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "Money.Mortgages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NumberOfMonths = c.Int(nullable: false),
                        LoanAmount = c.Decimal(nullable: false, storeType: "money"),
                        StartDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "Money.Transactions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Amount = c.Decimal(nullable: false, storeType: "money"),
                        Date = c.DateTime(nullable: false),
                        Mortgage_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("Money.Mortgages", t => t.Mortgage_Id)
                .Index(t => t.Mortgage_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("Money.Transactions", "Mortgage_Id", "Money.Mortgages");
            DropIndex("Money.Transactions", new[] { "Mortgage_Id" });
            DropTable("Money.Transactions");
            DropTable("Money.Mortgages");
        }
    }
}
