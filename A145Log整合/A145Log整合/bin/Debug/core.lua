--[[function GetInformathion(Filename)
    local f=io.open(Filename,"r");
    if(f==nil) then
    msgbox("�ļ�������"..Filename);
	return ;
	end
    local content=f:read("all");
    f:close();
	--"Unit%s+----------->%,%,%,%,%,%,%,Ohm%,Ohm%,Ohm%,Ohm%,Ohm%,Ohm%,Ohm%,Ohm%,Ohm%,Ohm\n"
	local SN,Pass_Fail_Status,ID,Fail_Item,Start_Time=
	local openshort1,openshort2,openshort3,openshort4,openshort5,openshort6,openshort7,openshort8,openshort9,openshort10=
	msgbox(content);
end--]]

--Header="Intelligent,V1.00,FCT\nSerial Number,Station ID,PASS/FAIL,Site ID,Fail Item,Start time,Test time,USB_DP1 to GND,USB_DN1 to GND,USBC_VBUS to GND,USBC_VCONN to GND,USBC_CC1 to GND,USBC_VBUS to USBC_CC1,USBC_VBUS to USBC_VCONN,USBC_CC1 to USB_DP1,USB_DP1 to USB_DN1,USBC_VBUS to USB_DN1\nupper Limited----------->,,,,,,,N/A,N/A,N/A,1500,N/A,N/A,N/A,N/A,N/A,N/A\nLower Limited----------->,,,,,,,10000,10000,10000,500,10000,10000,10000,10000,10000,10000\nUnit		   ----------->,,,,,,,Ohm,Ohm,Ohm,Ohm,Ohm,Ohm,Ohm,Ohm,Ohm,Ohm\n"

function lua_split(str, delimiter)
	if str==nil or str=='' or delimiter==nil then
		return nil
	end

    local result = {}
    for match in (str..delimiter):gmatch("(.-)"..delimiter) do
        table.insert(result, match)
    end
    return result
end


function split(str, split_char)
 local sub_str_tab = {};

 while (true) do
 local pos = string.find(str, split_char);
 if (not pos) then
  local size_t = table.getn(sub_str_tab)
  table.insert(sub_str_tab,size_t+1,str);
  break;
 end

 local sub_str = string.sub(str, 1, pos - 1);
 local size_t = table.getn(sub_str_tab)
 table.insert(sub_str_tab,size_t+1,sub_str);
 local t = string.len(str);
 str = string.sub(str, pos + 1, t);
 end
 if(not sub_str_tab) then
 msgbox("splitʧ��"..str)
 end
 return sub_str_tab;
end

function GetTestInfo(msg)--��ȡ���Ե�����
  local result={};
  result=split(msg,"\n");
  local _result={};
  local TestContent;
  if(result) then
    TestContent=result[#result-1];
	 --msgbox("TestContent:"..TestContent);
	 --msgbox(tostring(#result));
   _result=split(TestContent,",");
  end
  return _result;
end

function GetHeader(msg)
  local result={};
  result= split(msg,"\n");
  --local Lenth=result.len;
  local Header="";
  for key,value in ipairs(result) do
    if(key>=#result-1) then--���Ⱥ�������result.len
	  break;
	end
	  Header=Header..value.."\n";

  end
 return Header;
end

function CreatCSV(SourceFileName,DestFileName)--��ɴ���CSV�ļ�
  local f=io.open(DestFileName,"w");
  if(f==nil) then
    msgbox("�����ļ�ʧ��"..DestFileName);
	return;
  end

  local f1=io.open(SourceFileName,"r");
  if(f1==nil) then
    msgbox("��ȡ�ļ�ʧ��"..SourceFileName);
	return
  end

  local content=f1:read("*all");
   --msgbox(content);
  local table_content=GetTestInfo(content);--
  local str_table_content=table.concat(table_content,",");
  local Header=GetHeader(content);
  str_table_content=Header..str_table_content.."\n";
  f:write(str_table_content);
  f:close();
  f1:close();

end

function AppendCSV(SourceFileName,DestFileName)--��ɴ���CSV�ļ�
  local f1=io.open(SourceFileName,"r");
  if(f1==nil) then
    msgbox("��ȡ�ļ�ʧ��"..SourceFileName);
	return
  end

  local content=f1:read("*all");

  local f=io.open(DestFileName,"a");--׷�ӷ�ʽ
  if(f==nil) then
    msgbox("�����ļ�ʧ��"..DestFileName);
	return;
  end
  local table_content={}
  table_content=GetTestInfo(content);
  if(content==nil) then
  msgbox("csv�ĵ�����Ϊ��"..SourceFileName);
  end
  
  local str_table_content=table.concat(table_content,",");
  str_table_content=tostring(str_table_content).."\n";
  --str_table_content=Header..str_table_content;����Ҫheader
  assert(f:write(str_table_content),"write error"..SourceFileName);
  f1:close();
  f:close();

end
