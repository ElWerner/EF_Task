namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Customers : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tbl_customers",
                c => new
                    {
                        cln_customer_id = c.Int(nullable: false, identity: true),
                        cln_customer_name = c.String(),
                        cln_customer_address = c.String(),
                        cln_customer_city = c.String(),
                        cln_customer_state = c.String(),
                    })
                .PrimaryKey(t => t.cln_customer_id);

            Sql(@"insert into tbl_customers (cln_customer_name, cln_customer_address, cln_customer_city, cln_customer_state) values 
                ('Foo, Inc', '23 Main St., Thorpleburg', 'Thorpleburg', 'TX'),
                ('Freens R Us', '1600 Pennsylvania Avenue', 'Washington', 'DC')
                ");

            AddColumn("dbo.tbl_orders", "cln_order_customer_id", c => c.Int(nullable: false));
            CreateIndex("dbo.tbl_orders", "cln_order_customer_id");

            Sql(@"update tbl_orders set cln_order_customer_id = 1 where cln_order_id = 1");
            Sql(@"update tbl_orders set cln_order_customer_id = 2 where cln_order_id = 2");

            AddForeignKey("dbo.tbl_orders", "cln_order_customer_id", "dbo.tbl_customers", "cln_customer_id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tbl_orders", "cln_order_customer_id", "dbo.tbl_customers");
            DropIndex("dbo.tbl_orders", new[] { "cln_order_customer_id" });
            DropColumn("dbo.tbl_orders", "cln_order_customer_id");
            DropTable("dbo.tbl_customers");
        }
    }
}
