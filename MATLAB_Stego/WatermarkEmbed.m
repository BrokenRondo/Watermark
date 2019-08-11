function WatermarkEmbed(mat_image,LSB_Message)
mat_image=jpeg_read(mat_image);
temple=mat_image.coef_arrays;
temple=temple(1)
temple=temple{1,1}
img_dct=temple;

Embeded_img=img_dct;
Embeded_img=int16(Embeded_img);
%接下来将信息嵌入在DCT矩阵中，矩阵是8*8分块的，所以只需要嵌入在最左上角四个元素中
%对于每一个块：
fid=fopen(LSB_Message,'r');
strbin=[];
while ~feof(fid) %判断是否为文件的结尾
   
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
len=size(binary,2);%表示二进制有多少位
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
end
