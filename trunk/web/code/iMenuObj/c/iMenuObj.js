﻿/******************************************************************************
 * JavaScript Document
 * iMenuObj v2.0
 * http://www.amonsoft.cn/code/iMenuObj/
 * Copyright (c) 2008 Amonsoft.cn
 ******************************************************************************/
function iMenuObj(){var THIS = this;var NAME = 'iMenuObj';var HOST = 'http://www.amonsoft.cn/';var PATH = HOST + 'code/' + NAME + '/';THIS.OFFH = 0;THIS.OFFV = 0;var xFun;var mDiv;var wndW;var wndH;var tmpw;var tmph;THIS.showMenu = function(obj, div, w, h){THIS.view();mDiv = $X(div);if(!w || w < 1){w = 100;}wndW = w;if(!h || h < 1){h = 160;}wndH = h;var l = $L(obj);var x = l[0] + THIS.OFFH;var y = l[1] + THIS.OFFV + 16;var p = $P();var r = $R();if(x-r[0]+mDiv.clientWidth+20 > p[0]){x = x-mDiv.clientWidth+50;}if(y-r[1]+mDiv.clientHeight+obj.clientHeight+20 > p[1]){y = y-mDiv.clientHeight-20;}mDiv.style.width = '1px';mDiv.style.height = '1px';mDiv.style.left = x+'px';mDiv.style.top = (y+obj.clientHeight)+'px';mDiv.style.display = '';tmpw = 0;tmph = 0;stretchW();};THIS.exit = function(){xFun=setTimeout('imo.hide', 500);};THIS.view = function(){if(xFun != null){clearTimeout(xFun);xFun = null;}};THIS.hide = function(){var o=$X(NAME);if(o){o.style.display = 'none';}xFun = null;return false;};function stretchW(){if(tmpw >= wndW){stretchH();return ;}tmpw += 10;mDiv.style.width = tmpw + 'px';setTimeout(stretchW, 1);}function stretchH (){if(tmph >= wndH){return ;}tmph += 2;mDiv.style.height = tmph + 'px';setTimeout(stretchH, 2);}function $D(){return document;}function $X(obj){return $D().getElementById(obj);}}if(!imo)var imo = new iMenuObj();