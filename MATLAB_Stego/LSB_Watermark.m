function LSB_Watermark(mat_image,LSB_Message)
mat_image=jpeg_read(mat_image);
temple=mat_image.coef_arrays;
temple=temple(1)
temple=temple{1,1}
img_dct=temple;

Embeded_img=img_dct;
Embeded_img=int16(Embeded_img);
%����������ϢǶ����DCT�����У�������8*8�ֿ�ģ�����ֻ��ҪǶ���������Ͻ��ĸ�Ԫ����
%����ÿһ���飺
fid=fopen(LSB_Message,'r');
strbin=[];
while ~feof(fid) %�ж��Ƿ�Ϊ�ļ��Ľ�β
   
    M=fread(fid,1,'ubit8');
    if isempty(M)
        break;
    end
    for i=1:8
       A=bitget( M(1),8+1-i);
       strbin(end+1)=A;      
    end    
end


% LSB_Message=strcat(LSB_Message,'0000000000');
% str_t='start';
% str_t=strcat(str_t,LSB_Message);
% str=str_t;
binary = strbin;
len=size(binary,2);%��ʾ�������ж���λ
loc=1;
flag=0;
for i=1:8:size(Embeded_img,1)
    for j=1:8:size(Embeded_img,2)
        %t=bitget(Embeded_img(i,j),1:16);
        %c=binary(loc);
        emb=bitset(Embeded_img(i,j),1,binary(loc));
        Embeded_img(i,j)=emb;
        %t1=bitget(Embeded_img(i,j),1:16)
        loc=loc+1;
        emb=bitset(Embeded_img(i,j+1),1,binary(loc));
        Embeded_img(i,j+1)=emb;
        loc=loc+1;
        emb=bitset(Embeded_img(i+1,j),1,binary(loc));
        Embeded_img(i+1,j)=emb;
        loc=loc+1;
        emb=bitset(Embeded_img(i+1,j+1),1,binary(loc));
        Embeded_img(i+1,j+1)=emb;
        loc=loc+1;
        if loc>=len
            flag=1;
            break;
        end
    end
    if flag==1
        break;
    end
end
mat_image.coef_arrays{1,1}=double(Embeded_img);
jpeg_write(mat_image,'DCT_LSB.jpg');
% imshow(imread('0x.jpg'));
% Watermark=imread('0x.jpg');
% title('Ƕ��ˮӡ��ͼƬ');
% sigma=1;
% gausFilter=fspecial('gaussian',[5,5],sigma);
% Watermark_DCT=imfilter(Watermark,gausFilter,'replicate');
%imwrite('0x.jpg');
% figure
% imshow(imread('0G.jpg'));
% title('��˹�˲�');



%��������ȡˮӡ
loc=1;
Binary_array=[];

Marked=jpeg_read('DCT_LSB.jpg');
Embeded_img=Marked.coef_arrays{1,1};
Embeded_img=int16(Embeded_img);
for i=1:8:size(Embeded_img,1)
    for j=1:8:size(Embeded_img,2)
        Binary_array(end+1)=bitget(Embeded_img(i,j),1);
        %emb=bitset(Embeded_img(i,j),1,binary(loc));
        %Embeded_img(i,j)=emb;
        loc=loc+1;
        Binary_array(end+1)=bitget(Embeded_img(i,j+1),1);
        %emb=bitset(Embeded_img(i,j+1),1,binary(loc));
        %Embeded_img(i,j+1)=emb;
        loc=loc+1;
        Binary_array(end+1)=bitget(Embeded_img(i+1,j),1);
        %emb=bitset(Embeded_img(i+1,j),1,binary(loc));
        %Embeded_img(i+1,j)=emb;
        loc=loc+1;
        Binary_array(end+1)=bitget(Embeded_img(i+1,j+1),1);
        %emb=bitset(Embeded_img(i+1,j+1),1,binary(loc));
        %Embeded_img(i+1,j+1)=emb;
        loc=loc+1;
%         if loc>=len
%             flag=1;
%             break;
%         end
    end
%     if flag==1
%         break;
%     end
end
%���������ַ���ת��ΪASCII
str_e = char(bin2dec(reshape(char(Binary_array+'0'), 8,[]).'))
%disp(str_e);
str_e=str_e';
ofid=fopen('DCT_LSBExtracted.txt','w');
fwrite(ofid,str_e,'uchar');
fclose(ofid);
% k=strfind(str_e,'0000000000');
% t=str_e(1:6);
% if strcmp (str_e(1:5),'start')~=1
%    disp(str_e(1:100));
%    mark='ͼƬ����ˮӡ';
%    return;
% end
% mark=str_e(6:k(1)-1);
% disp(mark)
end
