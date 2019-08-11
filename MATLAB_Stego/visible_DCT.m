function visible_DCT(src,watermark)
X=imread(watermark);
X=rgb2gray(X);
%X=double(X);
[a,b]=size(X);
X=double(X);
T=dctmtx(8);

%进行DCT变换

Y = blkproc(X,[8,8],'P1*x*P2',T,T');
%Y=blkproc(X,[16 16],'dct2');
Xi =blkproc(Y,[8 8],'P1*x*P2',T',T);
%Xi=blkproc(Y,[8 8],'idct2');

% figure
% subplot(1,3,1);
% imshow(X);
% title('原始图片');
% 
% subplot(1,3,2);
% imshow(uint8(Y));
% title('分块DCT');
% 
% subplot(1,3,3);
% imshow(uint8(Xi));
% title('分块iDCT恢复图');

%接下来读入水印进行分块DCT
Watermark=imread(src);
Watermark=rgb2gray(Watermark);
Watermark=double(Watermark);
[a1,b1]=size(Watermark);
Watermark_DCT = blkproc(Watermark,[8,8],'P1*x*P2',T,T');
%Watermark_DCT=blkproc(Watermark,[16 16],'dct2');
Watermark_iDCT =blkproc(Watermark,[8 8],'P1*x*P2',T',T);
%Watermark_iDCT=blkproc(Watermark_DCT,[16 16],'idct2');

% figure
% subplot(1,3,1);
% imshow(uint8(Watermark));
% title('原始图片');
% subplot(1,3,2);
% imshow(uint8(Watermark_DCT));
% title('分块DCT');
% subplot(1,3,3);
% imshow(uint8(Watermark_iDCT));

%然后把水印嵌入
%对水印DCT矩阵的每一个像素来说
for i=1:size(Y,1)
    for j=1:size(Y,2)
        if(Y(i,j)~=0)
            Watermark_DCT(i,j)=0.95*Watermark_DCT(i,j)+0.05*Y(i,j);
        end
    end
end
%sigma=1;
%gausFilter=fspecial('gaussian',[5,5],sigma);
%Watermark_DCT=imfilter(Watermark_DCT,gausFilter,'replicate');
%Watermark_DCT=imresize(Watermark_DCT,1.1);
%Watermark_DCT=imcrop(Watermark_DCT,[50,50,500,500]);
Watermark_iDCT =blkproc(Watermark_DCT,[8 8],'P1*x*P2',T',T);
%Watermark_iDCT=blkproc(Watermark_DCT,[8 8],'idct2');
%figure
%imshow(Watermark_iDCT,[]);
imwrite(uint8(Watermark_iDCT),'visible_DCT.bmp');

% figure
% gausFilter=fspecial('gaussian',[5,5],sigma);
% gaus=imfilter(Watermark_iDCT,gausFilter,'replicate');
% imshow(gaus,[]);
end

