function extract_robust(marked_matrix,src_matrix,strength,len,ii,jj,logistic)
B=zeros(1,len);
B(1)=logistic;
for i=1:len-1
    B(i+1)=3.57*B(i)*(1-B(i));
end
for j=1:len
    if B(j)<0.5
        B(j)=0;
    else
        B(j)=1;
    end
end
marked_matrix=imread(marked_matrix);
src_matrix=imread(src_matrix);
if size(marked_matrix,1)~=size(src_matrix,1)
    disp('ˮӡ��ԭͼ��С��ͬ');
    return ;
end
extract_matrix=[];
for i=1:ii:size(marked_matrix,1)
    for j=1:jj:size(marked_matrix,2)
        Dif=abs(marked_matrix(i,j)-src_matrix(i,j));
        if Dif>=strength/2
            extract_matrix(end+1)=1;
        else
            extract_matrix(end+1)=0;
        end
    end
end
%����һ������ȡ���˶����Ƶ���Ƶ��Ϣ���У�Ȼ����α������н������,ÿlen��һ�����һ��,
%Ȼ��ó���������Ϣ���У�Ȼ��תΪԭʼ��Ϣ
loc=1;%������λ�Ѿ�����������
src_msg_vec=[];
% extract_matrix=extract_matrix(1:448);
% extract_matrix=extract_matrix(end:-1:1);
for i=1:len:size(extract_matrix,2)
    t=extract_matrix(loc:loc+len-1);
    t=xor(t,B);
    true_num=0;
    for j=1:size(t,2)
        if t(j)==1
            true_num=true_num+1;
        end
    end
    if true_num>(len/2+1)
        src_msg_vec(end+1)=1;
    else
        src_msg_vec(end+1)=0;
    end
    loc=loc+len;
    if loc+len-1>=size(extract_matrix,2)
        break;
    end
end
%���������������ַ���תΪʮ�����ַ�����ÿ8bitһת�����������֧��GBK����
%src_msg_vec=uint8(src_msg_vec);
src_msg_dec=[];
for i=1:8:size(src_msg_vec,2)
    str='';
    for j=0:7
        str=strcat(str,num2str(src_msg_vec(i+j)));
    end
    src_msg_dec(end+1)=bin2dec(str);
    if i+j+8>=size(src_msg_vec,2)
        break;
    end
end
fid=fopen('RobustExtracted.txt','wb');
fwrite(fid,src_msg_dec);
fclose(fid);
    


            