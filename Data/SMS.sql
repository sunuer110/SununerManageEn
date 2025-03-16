
GO
/****** Object:  Table [dbo].[SMS]    Script Date: 2025/3/15 17:16:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SMS](
	[SMSID] [int] IDENTITY(1,1) NOT NULL,
	[CreateDate] [datetime] NULL,
	[Phone] [nvarchar](50) NULL,
	[ClassID] [int] NULL,
	[Number] [int] NULL,
	[Flag] [int] NULL,
	[IsOk] [int] NULL,
	[IP] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[SMSID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SMSRule]    Script Date: 2025/3/15 17:16:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SMSRule](
	[Rid] [int] IDENTITY(1,1) NOT NULL,
	[Statue] [int] NULL,
	[RIP] [int] NULL,
	[RNum] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Rid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[SMS] ADD  DEFAULT (getdate()) FOR [CreateDate]
GO
ALTER TABLE [dbo].[SMS] ADD  DEFAULT ((0)) FOR [ClassID]
GO
ALTER TABLE [dbo].[SMS] ADD  DEFAULT ((0)) FOR [Number]
GO
ALTER TABLE [dbo].[SMS] ADD  DEFAULT ((0)) FOR [Flag]
GO
ALTER TABLE [dbo].[SMS] ADD  DEFAULT ((0)) FOR [IsOk]
GO
ALTER TABLE [dbo].[SMSRule] ADD  DEFAULT ((0)) FOR [Statue]
GO
ALTER TABLE [dbo].[SMSRule] ADD  DEFAULT ((0)) FOR [RIP]
GO
ALTER TABLE [dbo].[SMSRule] ADD  DEFAULT ((0)) FOR [RNum]
GO
/****** Object:  StoredProcedure [dbo].[SMS_Add]    Script Date: 2025/3/15 17:16:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
------------------------------------
--Add a Record
--Project Name：Sunuer Manage
--Table Name：SMS
--BY:HaiDong
--DateTime:2025-01-06 08:40:06
------------------------------------
create  procedure [dbo].[SMS_Add]
(
@Phone nvarchar(50),
@ClassID int,
@Number nvarchar(10),
@IP nvarchar(50)
)
as
declare @fanhui as int--Return Parameters
declare @SMSID as int--Verification Code ID
declare @Statue as int
declare @RIP as int
declare @RNum as int
set @fanhui=0
set @RIP=0
set @RNum=0

select top 1 @Statue=Statue,@RIP=RIP,@RNum=RNum from dbo.SMSRule order by 1 desc--Retrieve the Latest Information Rule

if(select count(SMSID) from SMS where Phone=@Phone and datediff(second,CreateDate,GETDATE())<61)=0--Has a Verification Code Been Sent Within the Last 60 Seconds
	begin
        if @RIP=0--IP Not Restricted
           begin
              if @RNum=0--User Sending Limit Not Restricted
				   begin
		             insert SMS(Phone,ClassID,Number,IP)values(@Phone,@ClassID,@Number,@IP)
		           set  @fanhui=-3--Added Successfully
				   end
				else --User Sending Limit Restricted
				   begin
		              if(select count(SMSID) from SMS where Phone=@Phone and datediff(day,Createdate,GETDATE())<1)<@RNum--Has the Number of Messages Sent Today Remained Below the Set Limit
							begin--Less Than Limit, Insert and Send
							   insert SMS(Phone,ClassID,Number,IP)values(@Phone,@ClassID,@Number,@IP)
							  set @fanhui=-3--Added Successfully
							end
					  else--Greater Than Limit, Do Not Send, Return Notification
							begin
							 set @fanhui=-2--Daily Sending Limit Exceeded
							end
				   end
           end
        else--IP Not Restricted
           begin
              if(select count(SMSID) from SMS where IP=@ip and datediff(day,Createdate,GETDATE())<1)<@RIP--Has the Number of Messages Sent from This IP Today Remained Below the Set Limit?
					begin
						  if @RNum=0--User Sending Limit Not Restricted
						   begin
							 insert SMS(Phone,ClassID,Number,IP)values(@Phone,@ClassID,@Number,@IP)
							set @fanhui=-3
						   end
						else --User Sending Limit Restricted
						   begin
							  if(select count(SMSID) from SMS where Phone=@Phone and datediff(day,Createdate,GETDATE())<1)<@RNum--Has the Number of Messages Sent Today Remained Below the Set Limit
									begin--Less Than Limit, Insert and Send
									   insert SMS(Phone,ClassID,Number,IP)values(@Phone,@ClassID,@Number,@IP)
									  set @fanhui=-3
									end
							  else--Greater Than Limit, Do Not Send, Return Notification
									begin
									 set @fanhui=-2
									end
						   end
					end
			    else
			        begin
			           set @fanhui=-4--The Number of Messages Sent from the Same IP Exceeds the Set Limit
			        end	
             
             
           end
       
	end
else 
	begin
        set @fanhui=-1 --Cannot Resend Within 60 Seconds
	end

return @fanhui
GO
/****** Object:  StoredProcedure [dbo].[SMS_Check]    Script Date: 2025/3/15 17:16:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
------------------------------------
--Verify if the Information is Correct
--Project Name：Sunuer Manage
--Table Name：SMS
--BY:HaiDong
--DateTime:2025-01-06 08:40:06
------------------------------------
create  procedure [dbo].[SMS_Check]
(
@Phone nvarchar(50),
@ClassID int,
@Number  nvarchar(10),
@IP nvarchar(50)
)
as

if(select count(SMSID) from SMS where Phone=@Phone and ClassID=@ClassID  and Number=@Number  and IP=@IP  and datediff(second,Createdate,GETDATE())<301)=1
	begin
	update  SMS set IsOk=1 where Phone=@Phone and ClassID=@ClassID  and Number=@Number and IP=@IP
	  return -1--Fully Meets the Requirements
	end 
else
    begin
    update  SMS set Flag=Flag+1 where Phone=@Phone and ClassID=@ClassID  and Number=@Number and IP=@IP
      return -2--Does Not Meet the Search Criteria
    end
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Creation Time' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMS', @level2type=N'COLUMN',@level2name=N'CreateDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Phone Number/Email' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMS', @level2type=N'COLUMN',@level2name=N'Phone'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Data Type (1: Registration Verification, 2: Password Recovery Verification, 3: Login Verification)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMS', @level2type=N'COLUMN',@level2name=N'ClassID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Verification Code' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMS', @level2type=N'COLUMN',@level2name=N'Number'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Failed Verification Attempts (Not Entered by the Owner)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMS', @level2type=N'COLUMN',@level2name=N'Flag'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Usage Status (0 = Not Used, 1 = Used)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMS', @level2type=N'COLUMN',@level2name=N'IsOk'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'IP' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMS', @level2type=N'COLUMN',@level2name=N'IP'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Verification Code Rules' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMSRule', @level2type=N'COLUMN',@level2name=N'Rid'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Is Active (0 = Active, 1 = Inactive)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMSRule', @level2type=N'COLUMN',@level2name=N'Statue'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Is IP Restricted (0 = No Restriction, 1 = Restricted: How many messages can one IP send per day?)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMSRule', @level2type=N'COLUMN',@level2name=N'RIP'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Is Message Count Restricted (0 = No Restriction, 1 = Restricted: Per Day)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMSRule', @level2type=N'COLUMN',@level2name=N'RNum'
GO
