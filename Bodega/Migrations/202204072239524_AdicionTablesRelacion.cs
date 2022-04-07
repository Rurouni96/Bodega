namespace Bodega.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AdicionTablesRelacion : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Cliente", "clasificacionClientes_ClasificacionId", c => c.Int());
            AddColumn("dbo.Pedido", "Cliente_ProductoId", c => c.Int());
            CreateIndex("dbo.Cliente", "clasificacionClientes_ClasificacionId");
            CreateIndex("dbo.PedidoDetalle", "PedidoId");
            CreateIndex("dbo.PedidoDetalle", "ProductoId");
            CreateIndex("dbo.Pedido", "Cliente_ProductoId");
            CreateIndex("dbo.Producto", "ClasificacionProductoId");
            CreateIndex("dbo.Producto", "UnidadMedidaId");
            AddForeignKey("dbo.Cliente", "clasificacionClientes_ClasificacionId", "dbo.ClasificacionCliente", "ClasificacionId");
            AddForeignKey("dbo.Pedido", "Cliente_ProductoId", "dbo.Cliente", "ProductoId");
            AddForeignKey("dbo.PedidoDetalle", "PedidoId", "dbo.Pedido", "PedidoId");
            AddForeignKey("dbo.Producto", "ClasificacionProductoId", "dbo.ClasificacionProducto", "ClasificacionProductoId");
            AddForeignKey("dbo.Producto", "UnidadMedidaId", "dbo.Unidad", "UnidadMedidaId");
            AddForeignKey("dbo.PedidoDetalle", "ProductoId", "dbo.Producto", "ProductoId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PedidoDetalle", "ProductoId", "dbo.Producto");
            DropForeignKey("dbo.Producto", "UnidadMedidaId", "dbo.Unidad");
            DropForeignKey("dbo.Producto", "ClasificacionProductoId", "dbo.ClasificacionProducto");
            DropForeignKey("dbo.PedidoDetalle", "PedidoId", "dbo.Pedido");
            DropForeignKey("dbo.Pedido", "Cliente_ProductoId", "dbo.Cliente");
            DropForeignKey("dbo.Cliente", "clasificacionClientes_ClasificacionId", "dbo.ClasificacionCliente");
            DropIndex("dbo.Producto", new[] { "UnidadMedidaId" });
            DropIndex("dbo.Producto", new[] { "ClasificacionProductoId" });
            DropIndex("dbo.Pedido", new[] { "Cliente_ProductoId" });
            DropIndex("dbo.PedidoDetalle", new[] { "ProductoId" });
            DropIndex("dbo.PedidoDetalle", new[] { "PedidoId" });
            DropIndex("dbo.Cliente", new[] { "clasificacionClientes_ClasificacionId" });
            DropColumn("dbo.Pedido", "Cliente_ProductoId");
            DropColumn("dbo.Cliente", "clasificacionClientes_ClasificacionId");
        }
    }
}
