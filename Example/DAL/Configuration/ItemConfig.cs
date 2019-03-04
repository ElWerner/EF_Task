﻿using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Configuration
{
    public class ItemConfig : EntityTypeConfiguration<Item>
    {
        public ItemConfig()
        {
            this.ToTable("tbl_items").HasKey(item => item.Id);
            this.Property(item => item.Id).HasColumnName("cln_item_id");
            this.Property(item => item.Description).HasColumnName("cln_item_description");
            this.Property(item => item.Price).HasColumnName("cln_item_price");

            /*this.HasMany<Order>(item => item.Orders)
                .WithMany(order => order.Items)
                .Map(oi =>
                {
                    oi.MapLeftKey("cln_item_id");
                    oi.MapRightKey("cln_order_id");
                    oi.ToTable("tbl_order_items");
                });*/

            this.HasMany<OrderItem>(oi => oi.OrderItems)
               .WithRequired(oi => oi.Item)
               .HasForeignKey(oi => oi.ItemId);
        }
    }
}
