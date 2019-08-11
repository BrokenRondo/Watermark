function FileIO(mat_image,ifn, ofn)
%fid=fopen（文件名,'打开方式'）
%说明：其中fid用于存储文件句柄值，如果返回的句柄值大于0，则说明文件打开成功。文件名用字符串形式，表示待打开的数据文件。常见的打开方式如下：
%? ? ? ‘r’：只读方式打开文件（默认的方式），该文件必须已存在。
%? ? ? ‘r+’：读写方式打开文件，打开后先读后写。该文件必须已存在。
%? ? ? ‘w’：打开后写入数据。该文件已存在则更新；不存在则创建。
%? ? ? ‘w+’：读写方式打开文件。先读后写。该文件已存在则更新；不存在则创建。
%? ? ? ‘a’：在打开的文件末端添加数据。文件不存在则创建。
%? ? ? ‘a+’：打开文件后，先读入数据再添加数据。文件不存在则创建。
%另外，在这些字符串后添加一个“t”，如‘rt’或‘wt+’，则将该文件以文本方式打开；如果添加的是“b”，则以二进制格式打开，这也是fopen函数默认的打开方式。
% ifid=fopen(ifn,'r'); %打开读取文件
% ofid=fopen(ofn,'w');
% LSB_Message=[];
% while ~feof(ifid) %判断是否为文件的结尾
%     A =fread(ifid,1,'char');
%     LSB_Message(end+1)=A;
%     %fwrite(ofid,A,'char');
% end
% fclose(ifid);
% mark=LSB_Watermark(mat_image,LSB_Message);
% if mark~='图片不含水印'
%     while ~feof(
% 
% fclose(ofid);
s=textread(ifn,'%s')
s=s{1,1};
mark=LSB_Watermark(mat_image,s)
fid=fopen(ofn,'w');
fprintf(fid,'%s',mark);
end

