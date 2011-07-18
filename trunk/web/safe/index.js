function scd()
{
    $('#ifCd').attr('src','cat.aspx');
    $('#dvCd').dialog({
            width: 310,
			height: 210,
			resizable:false,
			modal: true
		});
    return false;
}
function skd()
{
    $('#ifKd').attr('src','key.aspx');
    $('#dvKd').dialog({
            width: 310,
			height: 210,
			resizable:false,
			modal: true
		});
    return false;
}
function abc()
{
    var x=$(window);
    var w=(x.width()-20)/2;
    var h=x.height()-206;
    $('#TdTa').height(h);
    $('#DvSt').offset({'top':0,'left':0}).width(w).height(h);
    $('#DvOt').offset({'top':0,'left':w}).width(20).height(h);
    $('#DvDt').offset({'top':0,'left':w+20}).width(w).height(h);
}
$(window).resize(abc);
$(abc);

$('#TaSt').focus(function(){
    //$('#dvTp').show();
    //$('#dvTp').css({'top':0,'left':1});
});
$('#TaSt').blur(function(){
    //$('#dvTp').hide();
});