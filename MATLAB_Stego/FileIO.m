function FileIO(mat_image,ifn, ofn)
%fid=fopen���ļ���,'�򿪷�ʽ'��
%˵��������fid���ڴ洢�ļ����ֵ��������صľ��ֵ����0����˵���ļ��򿪳ɹ����ļ������ַ�����ʽ����ʾ���򿪵������ļ��������Ĵ򿪷�ʽ���£�
%? ? ? ��r����ֻ����ʽ���ļ���Ĭ�ϵķ�ʽ�������ļ������Ѵ��ڡ�
%? ? ? ��r+������д��ʽ���ļ����򿪺��ȶ���д�����ļ������Ѵ��ڡ�
%? ? ? ��w�����򿪺�д�����ݡ����ļ��Ѵ�������£��������򴴽���
%? ? ? ��w+������д��ʽ���ļ����ȶ���д�����ļ��Ѵ�������£��������򴴽���
%? ? ? ��a�����ڴ򿪵��ļ�ĩ��������ݡ��ļ��������򴴽���
%? ? ? ��a+�������ļ����ȶ���������������ݡ��ļ��������򴴽���
%���⣬����Щ�ַ��������һ����t�����确rt����wt+�����򽫸��ļ����ı���ʽ�򿪣������ӵ��ǡ�b�������Զ����Ƹ�ʽ�򿪣���Ҳ��fopen����Ĭ�ϵĴ򿪷�ʽ��
% ifid=fopen(ifn,'r'); %�򿪶�ȡ�ļ�
% ofid=fopen(ofn,'w');
% LSB_Message=[];
% while ~feof(ifid) %�ж��Ƿ�Ϊ�ļ��Ľ�β
%     A =fread(ifid,1,'char');
%     LSB_Message(end+1)=A;
%     %fwrite(ofid,A,'char');
% end
% fclose(ifid);
% mark=LSB_Watermark(mat_image,LSB_Message);
% if mark~='ͼƬ����ˮӡ'
%     while ~feof(
% 
% fclose(ofid);
s=textread(ifn,'%s')
s=s{1,1};
mark=LSB_Watermark(mat_image,s)
fid=fopen(ofn,'w');
fprintf(fid,'%s',mark);
end

