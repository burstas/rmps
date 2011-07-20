﻿
$('#TaSt').focus(function(){
    //$('#dvTp').show();
    //$('#dvTp').css({'top':0,'left':1});
});
$('#TaSt').blur(function(){
    //$('#dvTp').hide();
});
/**
 * 切换输入输出
 */
$('#IbMd').click(function(){
    var sc=$('#TaSt');
    var dc=$('#TaDt');
    var st=sc.val();
    var dt=dc.val();
    sc.val(dt);
    dc.val(st);

    var img=$('#IbMd');
    var md=(img.attr('checked')||'false').toLowerCase();
    img.attr('checked',"true"==md?'false':'true');
});
/**
 * 字符集
 */
$('#LbMc').click(function()
{
    $('#ifCd').attr('src','cat.aspx');
    $('#dvCd').dialog({
            width: 310,
			height: 210,
			resizable:false,
			modal: true
		});
    return false;
});
/**
 * 密钥对
 */
$('#IbKd').click(function()
{
    $('#ifKd').attr('src','key.aspx');
    $('#dvKd').dialog({
            width: 310,
			height: 210,
			resizable:false,
			modal: true
		});
    return false;
});
function ChangeAction()
{
    var hdn=$('#HdMd')
    var md=hdn.val();
    hdn.val(md?'1':'0');
}
/**
 * 切换方案
 */
$('#CbMc').change(function ChangeMethod()
    {
        var mc=$('#CbMc').val();
        var mf=$('#CbMf');
        var ml=$('#CbMl');
        mf.empty();
        
        if(mc=='digest')
        {
            mf.append('<option value="MD5">MD5</option>');
            mf.append('<option value="SHA1">SHA-1</option>');
            mf.append('<option value="SHA256">SHA-256</option>');
            mf.append('<option value="SHA384">SHA-384</option>');
            mf.append('<option value="SHA512">SHA-512</option>');
            mf.show();
            ml.hide();
            return;
        }
        if (mc=='confuse')
        {
            mf.append('<option value="1">1位掩码</option>');
            mf.append('<option value="2">2位掩码</option>');
            mf.append('<option value="3">3位掩码</option>');
            mf.append('<option value="4">4位掩码</option>');
            mf.append('<option value="5">5位掩码</option>');
            mf.append('<option value="6">6位掩码</option>');
            mf.append('<option value="7">7位掩码</option>');
            mf.append('<option value="8">8位掩码</option>');
            mf.show();
            ml.hide();
            return;
        }
        if (item.Value == CAT_PRIVATE)
        {
            mf.append('<option value="DES">DES</option>');
            mf.append('<option value="TripleDES">三重DES</option>');
            mf.append('<option value="AES">AES</option>');
            mf.append('<option value="Rijndael">Rijndael</option>');
            mf.show();
            ml.hide();
            return;
        }
        if (item.Value == CAT_PUBLIC)
        {
            mf.append('<option value="RSA">RSA</option>');
            mf.show();
            ml.hide();
            return;
        }
        if (item.Value == CAT_DIGITAL)
        {
            mf.append('<option value="RSA">RSA</option>');
            mf.append('<option value="DSA">DSA</option>');
            mf.show();
            ml.hide();
            return;
        }
        mf.hide();
        ml.hide();
    });
function abc()
{
    var w=self.innerWidth||(document.documentElement.clientWidth||document.body.clientWidth);
    var h=self.innerHeight||(document.documentElement.clientHeight||document.body.clientHeight);
    w=(w-64)/2;
    h=h-190;
    $('#TaSt').width(w).height(h);
    $('#TaDt').width(w).height(h);
}
$(window).resize(abc);
$(abc);