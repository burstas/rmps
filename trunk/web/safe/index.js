function scd()
{
    $('#ifCd').attr('src','cat.aspx');
    $('#dvCd').dialog({
            width: 310,
			height: 210,
			modal: true
		});
    return false;
}
function abc()
{
    var x=$(window);
    var w=x.width();
    var h=x.height()-86;
    $('#TdSt').height(h);
    $('#TdOt').height(h);
    $('#TdDt').height(h);
}
$(window).resize(abc);
$(abc);