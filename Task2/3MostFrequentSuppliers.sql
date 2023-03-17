SELECT top 3 (select name from Suppliers where Supplier_ID = d.Supplier_ID) as Supplier, count(*) 
from Delivery d
group by Supplier_ID
order by count(*) desc;
