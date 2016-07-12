SELECT     
	b.BankName, m.ModelName, v.ValueTypeName, count(distinct T.TerminalSerialNo)
FROM       
Terminal T (nolock)      
INNER JOIN Webrequest W (nolock) On w.terminalserialno = T.terminalserialno      
INNER JOIN Model M (nolock) ON M.modelid = t.modelid    
INNER JOIN Bank b on b.BankId = T.BankId
INNER JOIN ValueType V on V.ValueTypeID = t.ComTypeId   
WHERE w.CreatedDate >= '1-Dec-2015'    AND w.CreatedDate < '1-JAn-2016'
GROUP BY      
b.BankName, m.ModelName, v.ValueTypeName






--WITH CTE AS(
--select VT.ModelName,r.CreatedDate,
--             RANK() over (partition by R.TerminalSerialNo order by WebRequestId) as seqnum
--      from WebRequest R
--      INNER JOIN vwTerminalMaster VT ON VT.TerminalSerialNo=R.TerminalSerialNo
--      where YEAR(CreatedDate)=2016
--      and MONTH(CreatedDate)=1
--      and VT.bankId=24
--and VT.ComTypeId='GPRS'
--      )
--      select COUNT(*) as 'Hit Count',ModelName from CTE where CTE.seqnum=1
--      GROUP by ModelName
     