function Test2()
   local a=GetNewForm();
   --local a={2,2,2};
  -- msgbox(tostring(a[1]));
   --msgbox(tostring(a[2]));
  -- msgbox(tostring(a[3]));
  --a.Test();
  local b=GetColor("red");
  --a.msgbox("����Lua�ű�����Ŷ��")
  a.ForeColor=b;
  a.Text="����Lua�ű�����Ŷ��";
  --msgbox(type(a));
  return a;
end
