# Enity Framework Homework

### Console App should display list of customers:  
•	display every order for the customer including InvoiceNo and date of order;  
•	display every item of the order including description, price and quantity  

### The task should be done in four migrations:
1.	Initial migration – create entity Item (cln_item_id (PK) and cln_description columns), map this entity on DB, create migration and initialize table tbl_items with data.
2.	Create entity Order, which is related to Item entity using many-to-many relationship. Subsidiary table should have tbl_order_items name and cln_order_id and cln_item_id columns. Initialize these tables with data.
3.	Create table tbl_order_items instead of many-to-many relationship using OrderItem entity. This entity should also store amount of items in order (Quantity). OrderItem will be connected with Item and Order entities using one-to-many relationship. Create update for tbl_order_items table in migration, insert quantity of items for each row.
4.	Add info about customer (Customer entity: Customer No  -  PK). Every customer may have several orders (see International Widgets.xlsx file).


•	Every tables in database should have “tbl_” prefix, and every column should have “cln_” prefix.  
•	Use EF Fluent API for entity mapping. Entities configurations should located in separate classes.  
•	Use Sql method and sql queries in migrations instead of usind Seed method in Configuration class, for examlpe:  
   ``Sql(@"insert into tbl_items (cln_description, cln_price) values   
                 ('56'' Blue Freen', 3.5),  
                 ('Spline End (Xtra Large)', 0.25)  
                ");  ``  
•	Use MigrateDatabaseToLatestVersion DB initializer.  
•	Optional: use EF eager loading in console app.  
