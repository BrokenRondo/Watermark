function [out_image]=junzhilvbo(input,option)
switch option
    case '1'
        out_image=filter2(fspecial('average',3),input)/255;
    case '2'
        out_image=filter2(fspecial('average',5),input)/255;
    case '3'
        out_image=filter2(fspecial('average',7),input)/255;
    otherwise
        out_image=filter2(fspecial('average',9),input)/255;
end
imshow(out_image);
end