namespace SGRE.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InicialCreacionTablas : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Choferes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 150),
                        Licencia = c.String(nullable: false, maxLength: 30),
                        TelefonoEmergencia = c.String(maxLength: 20),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Clientes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 150),
                        RFC = c.String(nullable: false, maxLength: 13),
                        Telefono = c.String(maxLength: 20),
                        Direccion = c.String(maxLength: 300),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Envios",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ClienteId = c.Int(nullable: false),
                        ChoferId = c.Int(nullable: false),
                        VehiculoId = c.Int(nullable: false),
                        OrigenDireccion = c.String(nullable: false, maxLength: 300),
                        DestinoDireccion = c.String(nullable: false, maxLength: 300),
                        FechaCreacion = c.DateTime(nullable: false),
                        FechaEntregaEstimada = c.DateTime(),
                        Estatus = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Choferes", t => t.ChoferId, cascadeDelete: true)
                .ForeignKey("dbo.Clientes", t => t.ClienteId, cascadeDelete: true)
                .ForeignKey("dbo.Vehiculos", t => t.VehiculoId, cascadeDelete: true)
                .Index(t => t.ClienteId)
                .Index(t => t.ChoferId)
                .Index(t => t.VehiculoId);
            
            CreateTable(
                "dbo.EstatusHistorial",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EnvioId = c.Int(nullable: false),
                        Estatus = c.Int(nullable: false),
                        FechaCambio = c.DateTime(nullable: false),
                        Comentario = c.String(maxLength: 500),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Envios", t => t.EnvioId, cascadeDelete: true)
                .Index(t => t.EnvioId);
            
            CreateTable(
                "dbo.Vehiculos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Placa = c.String(nullable: false, maxLength: 15),
                        Tipo = c.String(nullable: false, maxLength: 50),
                        Capacidad = c.Decimal(nullable: false, precision: 10, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Envios", "VehiculoId", "dbo.Vehiculos");
            DropForeignKey("dbo.EstatusHistorial", "EnvioId", "dbo.Envios");
            DropForeignKey("dbo.Envios", "ClienteId", "dbo.Clientes");
            DropForeignKey("dbo.Envios", "ChoferId", "dbo.Choferes");
            DropIndex("dbo.EstatusHistorial", new[] { "EnvioId" });
            DropIndex("dbo.Envios", new[] { "VehiculoId" });
            DropIndex("dbo.Envios", new[] { "ChoferId" });
            DropIndex("dbo.Envios", new[] { "ClienteId" });
            DropTable("dbo.Vehiculos");
            DropTable("dbo.EstatusHistorial");
            DropTable("dbo.Envios");
            DropTable("dbo.Clientes");
            DropTable("dbo.Choferes");
        }
    }
}
