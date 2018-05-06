SELECT 
	s.[transaction_date] AS [day], 
	d.[name] AS [department], 
	COUNT(s.[id]) AS [sale_count]
	--SUM(p.[price]) AS [sales_sum] 
FROM [sale] AS s 
	JOIN [department] AS d ON s.[department_id] = d.[id]
	--JOIN [product] AS p ON s.[product_id] = p.[id]
GROUP BY d.[name], s.[transaction_date]
ORDER BY d.[name] ASC, s.[transaction_date] ASC