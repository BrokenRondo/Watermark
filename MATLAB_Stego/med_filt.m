function [out_image]=med_filt(input,option)
switch option
    case '1'
        out_image=medfilt2(input);
    case '2'
        out_image=medfilt2(input,[5,5]);
    case '3'
        out_image=medfilt2(input,[7,7]);
    otherwise
        out_image=medfilt2(input,[9,9]);
end
imshow(out_image);
end
