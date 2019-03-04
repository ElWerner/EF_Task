namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OrderItems : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tbl_order_items", "cln_item_quantity", c => c.Int(nullable: false));

            Sql(@"update tbl_order_items set cln_item_quantity = 4 where (cln_item_id = 1 and cln_order_id = 1)");
            Sql(@"update tbl_order_items set cln_item_quantity = 32 where (cln_item_id = 2 and cln_order_id = 1)");
            Sql(@"update tbl_order_items set cln_item_quantity = 5 where (cln_item_id = 3 and cln_order_id = 1)");
            Sql(@"update tbl_order_items set cln_item_quantity = 500 where (cln_item_id = 1 and cln_order_id = 2)");
            Sql(@"update tbl_order_items set cln_item_quantity = 750 where (cln_item_id = 3 and cln_order_id = 2)");

        }
        
        public override void Down()
        {
            DropColumn("dbo.tbl_order_items", "cln_item_quantity");
        }
    }
}
