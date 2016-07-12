select t.banktid,m.tid,
(select top 1 status from [192.168.1.45].[AmexEdcTMSUAT].[EDC].[IntiStatus] i where i.tid=InitStatus.TID order by i.initdate desc) from [192.168.1.45].[AmexEdcTMSUAT].[EDC].[Merchant] m
INNER JOIN Terminal t on t.banktid=m.tid
LEFT JOIN 
(
select distinct TID
from [192.168.1.45].[AmexEdcTMSUAT].[EDC].[IntiStatus]
GROUP BY TID
) InitStatus ON InitStatus.TID=m.tid
select * from Terminal

select * from [192.168.1.45].[AmexEdcTMSUAT].[EDC].[IntiStatus]

select * from downloadlog