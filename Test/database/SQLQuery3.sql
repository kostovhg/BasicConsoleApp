WITH temp AS
	(
	SELECT 
	   ROW_NUMBER() OVER(ORDER BY  DATEFROMPARTS(YEAR([created_at]), MONTH([created_at]), 1)) AS [rn],
	   DATEFROMPARTS(YEAR([created_at]), MONTH([created_at]), 1) AS [date],
	   COUNT([title]) AS count
	 FROM [posts] 
	 GROUP BY  DATEFROMPARTS(YEAR([created_at]), MONTH([created_at]), 1)
	 )
 SELECT
    t1.[date],
    t1.[count],
	ISNULL(FORMAT(1 - (t2.[count] * 1.0 / t1.[count]), 'P1'), 'null') AS [percent_growth]
  FROM temp as t1
  LEFT JOIN temp AS t2 ON t1.[rn] = t2.[rn] + 1