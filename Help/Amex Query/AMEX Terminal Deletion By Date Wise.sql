
--select distinct TID  from edc.KeyData where cast(createddate as date)=cast('2016-01-15' as date) 
delete from EDC.TIDDetail where TID  in(select distinct TID  from edc.KeyData where cast(createddate as date)=cast('2016-01-15' as date) )
delete from edc.KeyData where cast(createddate as date)=cast('2016-01-15' as date) 
delete from edc.Acquirer where cast(createddate as date)=cast('2016-01-15' as date) 
delete from edc.CardRange where cast(createddate as date)=cast('2016-01-15' as date) 
delete from EDC.ChipData where cast(createddate as date)=cast('2016-01-15' as date) 
delete from edc.icc where cast(createddate as date)=cast('2016-01-15' as date) 
delete from edc.issuer where cast(createddate as date)=cast('2016-01-15' as date) 
delete from edc.Descriptor where cast(createddate as date)=cast('2016-01-15' as date) 
delete from EDC.TIDConfiguration where cast(createddate as date)=cast('2016-01-15' as date)

--select * from EDC.KeyData where TID='02077768'

