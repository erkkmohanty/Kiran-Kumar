--delete from Terminal where TerminalSerialNo in(
--select distinct t.TerminalSerialNo   from WebRequest w
--INNER JOIN Terminal T ON w.TerminalSerialNo=t.TerminalSerialNo  and t.BankId=34
--where t.BankId=34 and
--w.createdDate<='31/05/2015'
--and w.TerminalSerialNo not in (
--select distinct t.TerminalSerialNo   from WebRequest w
--INNER JOIN Terminal T ON w.TerminalSerialNo=t.TerminalSerialNo  and t.BankId=34
--where t.BankId=34 and
--w.createdDate>'31/05/2015'
--))



--delete from  Terminal where TerminalSerialNo in (select T.TerminalSerialNo from Terminal T where T.TerminalSerialNo not in (select distinct t.TerminalSerialNo  from WebRequest w
--INNER JOIN Terminal T ON w.TerminalSerialNo=t.TerminalSerialNo  and t.BankId=34
--where t.BankId=34) and BankId=34)