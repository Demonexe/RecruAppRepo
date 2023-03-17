CREATE VIEW [dbo].[Warehouse]
	AS SELECT r.Component_ID,
	(SELECT sum(Quantity) from dbo.Delivery where Component_ID = r.Component_ID) - 
	(SELECT sum(Quantity) from dbo.Release where Component_ID = r.Component_ID) as Quantity 
	FROM dbo.Release r
	group by r.Component_ID;
