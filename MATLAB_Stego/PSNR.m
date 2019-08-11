function peaksnr= PSNR(img,imgn)
img=imread(img);
imgn=imread(imgn);
peaksnr = psnr(img,imgn);
fprintf('psnr=%f',peaksnr)
end