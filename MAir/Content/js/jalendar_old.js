////////////////////////////////
// Author: Bora DAN — http://codecanyon.net/user/bqra
// 18 August 2013
// E-mail: bora_dan@hotmail.com
////////////////////////////////

$(function () {    
    (function ($) {
        $.fn.jalendar = function (options) {
            
            var settings = $.extend({
                customDay: new Date(),
                color: '#65c2c0',
                lang: 'EN'
            }, options);
           
            // Languages            
            var dayNames = {};
            var monthNames = {};
            var lAddEvent = {};
            var lAllDay = {};
            var lTotalEvents = {};
            var lEvent = {};
            dayNames['EN'] = new Array('周一', '周二', '周三', '周四', '周五', '周六', '周日');
            dayNames['TR'] = new Array('Pzt', 'Sal', 'Çar', 'Per', 'Cum', 'Cmt', 'Pzr');
            dayNames['ES'] = new Array('Lun', 'Mar', 'Mié', 'Jue', 'Vie', 'Såb', 'Dom');
            monthNames['EN'] = new Array('January', 'February', 'March', 'April', 'May', 'June', 'July', 'August', 'September', 'October', 'November', 'December'); 
            monthNames['TR'] = new Array('Ocak', 'Şubat', 'Mart', 'Nisan', 'Mayıs', 'Haziran', 'Temmuz', 'Ağustos', 'Eylül', 'Ekim', 'Kasım', 'Aralık'); 
            monthNames['ES'] = new Array('Enero', 'Febrero', 'Marzo', 'Abril', 'Mayo', 'Junio', 'Julio', 'Agosto', 'Septiembre', 'Octubre', 'Noviembre', 'Diciembre'); 
            lAddEvent['EN'] = '添加新事件';
            lAddEvent['TR'] = 'Yeni Etkinlik Ekle';
            lAddEvent['ES'] = 'Agregar Un Nuevo Evento';
            lAllDay['EN'] = '整天';
            lAllDay['TR'] = 'Tüm Gün';
            lAllDay['ES'] = 'Todo El Día';
            lTotalEvents['EN'] = '本月总事件: ';
            lTotalEvents['TR'] = 'Bu Ayki Etkinlik Sayısı: ';
            lTotalEvents['ES'] = 'Total De Eventos En Este Mes: ';
            lEvent['EN'] = '事件';
            lEvent['TR'] = 'Etkinlik';
            lEvent['ES'] = 'Evento(s)';
            
            
            var $this = $(this);
            var div = function (e, classN) {
                return $(document.createElement(e)).addClass(classN);
            };
            //事件的时间段的选定
            var clockHour = [];
            var clockMin = [];
            for (var i=0;i<24;i++ ){
                clockHour.push(div('div', 'option').text(i))
            }
            for (var i=0;i<59;i+=5 ){
                clockMin.push(div('div', 'option').text(i))
            }
            // HTML Tree
            $this.append(
                div('div', 'wood-bottom'), 
                div('div', 'jalendar-wood').append(
                  
                    div('div', 'jalendar-pages').append(
                       
                        div('div', 'header').css('background-color', settings.color).append(
                            div('a', 'prv-m'),
                            div('h1'),
                            div('a', 'nxt-m'),
                            div('div', 'day-names')
                       ), //
                       div('div', 'total-bar').html(lTotalEvents[settings.lang] + '<b style="color:"' + settings.color + '></b>'),
                       div('div', 'days')
                    ),
                    div('div', 'add-event').append(
                       
                        div('div', 'events').append(
                            
                            div('div', 'events-list')
                        )
                    )
                )
            );
            
            //添加天的小格
            for (var i = 0; i < 42; i++) {
                $this.find('.days').append(div('div', 'day'));
            }
            
            //绑定周
            for (var i = 0; i < 7; i++) {
                $this.find('.day-names').append(div('h2').text(dayNames[settings.lang][i]));
            }

            var d = new Date(settings.customDay);
            var year = d.getFullYear();
            var date = d.getDate();
            var month = d.getMonth();
            //闰年与否
            var isLeapYear = function(year1) {
                var f = new Date();
                f.setYear(year1);
                f.setMonth(1);
                f.setDate(29);
                return f.getDate() == 29;
            };
        
            var feb;
            var febCalc = function(feb) { 
                if (isLeapYear(year) === true) { feb = 29; } else { feb = 28; } 
                return feb;
            };
            var monthDays = new Array(31, febCalc(feb), 31, 30, 31, 30, 31, 31, 30, 31, 30, 31);

            function calcMonth() {

                monthDays[1] = febCalc(feb);
                
                var weekStart = new Date();
                weekStart.setFullYear(year, month, 0);
                var startDay = weekStart.getDay();
                var thingDay = 0;

                $this.find('.header h1').html(monthNames[settings.lang][month] + ' ' + year);
        
                $this.find('.day').html('&nbsp;');
                $this.find('.day').removeClass('this-month');
                for (var i = 1; i <= monthDays[month]; i++) {
                    startDay++;
                    var time = i.toString() + (month + 1).toString() + year.toString();
                    $this.find('.day').eq(startDay - 1).addClass('this-month').addClass(''+time+'').attr('data-date', i + '/' + (month + 1) + '/' + year).html(i);//eq找到数组的第几个
                }
                GN("show", month + 1, year.toString());
                if ( month == d.getMonth() ) {
                    $this.find('.day.this-month').removeClass('today').eq(date - 1).addClass('today').css('background-color', "yellow");
                } else {
                    $this.find('.day').removeClass('today').attr('style', '');
                }
                function GN(done ,time , year) {
                    if (1==1) {
                        $.post("daything.ashx?t=" + Math.random(), {done:done ,time: time ,year:year}, function (json) {
                            if (json.Data.length != 0) {
                                 if(1==1){
                                     var th = 0;
                                     //data = jQuery.parseJSON(json.Data);
                                     $.each(json.Data, function (i, item) {
                                         var kk = changeTime(item.day);
                                         var coun = item.context.split(',');
                                        thingDay++;
                                        $this.find('.day.this-month').eq(item.oneday - 1).prepend(
                                           div('div', 'event-single').addClass(''+kk.toString() + thingDay.toString()+'').attr('data-id', kk.toString() + thingDay.toString()).append(
                                               div('tr', '').text(item.rqlx + ':'),
                                               div('tr', '').text(item.title)
                                           )
                                       );
                                        if (coun.length > 0)
                                        {
                                            for (var k = 0; k < coun.length; k++) {
                                                $this.find('.day.this-month').eq(item.oneday - 1).find('.event-single.' + kk.toString() + thingDay.toString() + '').append(
                                                 div('tr', '').text(coun[k]));
                                            }
                                        }
                                        $this.find('.day.this-month').eq(item.oneday - 1).find('.event-single.' + kk.toString() + thingDay.toString() + '').append(
                                             div('div', 'details').append(
                                                   div('div', 'clock').text(item.day+' '+item.time),
                                                   div('div', 'erase'))
                                            );
                                     });
                                     //$this.find('.day.this-month.' + kk + '').has('.event-single').addClass('have-event' + kk + '').prepend(div('i', kk));//添加日期的标记
                                     $this.find('.day.this-month').has('.event-single').addClass('have-event').prepend(div('i', ''));//添加日期的标记
                                }
                            }
                            $this.find('.total-bar b').text(thingDay);
                        }, "json");
                    }
                }
                function changeTime(time)
                {
                    return time.replace("/", "").replace("/", "");
                } 
            }
            
            calcMonth();
            
            var arrows = new Array ($this.find('.prv-m'), $this.find('.nxt-m'));
            var dropdown = new Array ($this.find('.add-time .select span'), $this.find('.add-time .select .dropdown .option'), $this.find('.add-time .select'));
            var allDay = new Array ('.all-day fieldset[data-type="disabled"]', '.all-day fieldset[data-type="enabled"]');
            //var $close = $this.find('.jalendar-wood > .close-button');
            var $erase = $this.find('.event-single .erase');//事件数量
            $this.find('.jalendar-pages').css({'width' : $this.find('.jalendar-pages').width()});
            $this.find('.events').css('height', ($this.height() - 40));
            $this.find('.events').css('width', ($this.width() - 19));
            $this.find('.select .dropdown .option').hover(function() {
                $(this).css('background-color', settings.color); 
            }, function(){
                $(this).css('background-color', 'inherit'); 
            });
            var jalendarWoodW = $this.find('.jalendar-wood').width();
            var woodBottomW = $this.find('.wood-bottom').width();

             计算滚动
            function calcScroll()
            {
                if ($this.find('.events-list').height() < $this.find('.events').height())
                {
                    $this.find('.gradient-wood').hide();
                    $this.find('.events-list').css('border', 'none')
                }
                else
                {
                    $this.find('.gradient-wood').show();
                }
            }
            
             //Calculate total event again
            function calcTotalDayAgain() {
                var eventCount = $this.find('.this-month .event-single').length;//计算事件的数量
                $this.find('.total-bar b').text(eventCount);
                $this.find('.events h3 span b').text($this.find('.events .event-single').length)
            }


            //点击事件
            function prevAddEvent() {
                $this.find('.day').removeClass('selected').removeAttr('style');
                $this.find('.today').css('background-color', "yellow");
                $this.find('.add-event').hide();
                $this.children('.jalendar-wood').animate({'width' : jalendarWoodW} );
                $this.children('.wood-bottom').animate({'width' : woodBottomW});
                $close.hide();
            }
          
            arrows[1].on('click', function () {
                if ( month >= 11 ) {
                    month = 0;
                    year++;s
                } else {
                    month++;   
                }
                calcMonth();
                prevAddEvent();
            });
            arrows[0].on('click', function () {
                dayClick = $this.find('.this-month');
                if ( month === 0 ) {
                    month = 11;
                    year--;
                } else {
                    month--;   
                }
                calcMonth();
                prevAddEvent();
            });
            $this.on('mouseout', '.this-month', function () {
                prevAddEvent();
            });
            //点击事件，发现已经绑定的事件
            $this.on('mouseover', '.this-month', function () {
                var zz = $(this).find('.selected').attr('data-date');
                var eventSingle = $(this).find('.event-single');//找到日期下隐藏的事件，绑定出来
                $this.find('.events .event-single').remove();
                prevAddEvent();//隐藏上次选定日期的右边数据
                $(this).addClass('selected').css({ 'background-color': settings.color });
                //$(this).addClass('selected');
                //$this.children('.jalendar-wood, .wood-bottom').animate({width : '+=300px' }, 200, function() {
                $this.find('.add-event').show().find('.events-list').html(eventSingle.clone()).css({
                    "top": ($(".day.this-month.selected").height() - 300) + "px",
                    "left": ($(".day.this-month.selected").width() + 50) + "px"
                }).show(20000);
                $this.find('.add-new input').select();
                calcTotalDayAgain();
                calcScroll();
                $close.show();
                });
            //});

            
            dropdown[0].click(function(){
                dropdown[2].children('.dropdown').hide(0);
                $(this).next('.dropdown').show(0);
            });
            dropdown[1].click(function(){
                $(this).parent().parent().children('span').text($(this).text());
                dropdown[2].children('.dropdown').hide(0);
            });
            $('html').click(function(){
                dropdown[2].children('.dropdown').hide(0); 
            });
            $('.add-time .select span').click(function(event){
                event.stopPropagation(); 
            });
            
            $this.on('click', allDay[0], function(){
                $(this).removeAttr('data-type').attr('data-type', 'enabled').children('.check').children().css('background-color', settings.color);
                dropdown[2].children('.dropdown').hide(0);
                //$(this).parents('.all-day').prev('.add-time').css('opacity', '0.4').children('.disabled').css('z-index', '10');
            });
            $this.on('click', allDay[1], function(){
                $(this).removeAttr('data-type').attr('data-type', 'disabled').children('.check').children().css('background-color', 'transparent');
                $(this).parents('.all-day').prev('.add-time').css('opacity', '0.4').children('.disabled').css('z-index', '-1');
            });
            var thisDa = $this.find('.day.this-month').find('data-date');
            // 添加事件
            function GN(done, thisDay, time, title) {
                if (1 == 1) {
                    $.post("daything.ashx?t=" + Math.random(), {done:done, thisDay: thisDay, time: time, title: title }, function (json) {
                        if (json.Data[0].status) {
                            alert("添加成功！")
                        } else {
                            alert("操作失败！！！");
                        }
                    }, "json");
                }
            }
            $this.find('.submit').on('click', function(){
                var title = $(this).prev('input').val();//添加事件内容
                var hour = $(this).parents('.add-new').find('.hour > span').text();
                var min = $(this).parents('.add-new').find('.min > span').text();
                var isAllDay = $(this).parents('.add-new').find('.all-day fieldset').attr('data-type');
                var isAllDayText = $(this).parents('.add-new').find('.all-day fieldset label').text();
                var thisDay = $this.find('.day.this-month.selected').attr('data-date');
                var dt = thisDay.replace("/", "").replace("/", "");
                var dataId = parseInt($this.find('.total-bar b').text());
                var time;
                if ( isAllDay == 'disabled' ) {
                    time = hour + ':' + min;
                } else {
                    time = isAllDayText;
                }
                $.get("WebForm1.aspx", { title: title, day: thisDay, time: time });
                $this.prepend(div('div', 'added-event').attr({ 'data-date': thisDay, 'data-time': time, 'data-title': title, 'data-id': time.replace("/", "").replace("/", "") + dataId }));
               // GN("add" , thisDay, time, title);
                //增加事件的显示代码
                $this.find('.day.this-month.selected').prepend(
                    div('div', 'event-single').attr('data-id', $this.find('.day.this-month.selected').attr('data-date').replace("/", "").replace("/", "") + dataId).append(
                        div('p','').text(title),
                        div('div','details').append(
                            div('div', 'clock').text(time),
                            div('div', 'erase')
                        )
                    )
                );
                if ($this.find('.day').has('.event-single').find('.' + dt + '').length==0) {
                    $this.find('.day.'+dt+'').has('.event-single').addClass('have-event'+dt+'').prepend(div('i', dt));//给添加事件的日期添加标记
                }
               
                //$this.find('.events-list').html($this.find('.day.this-month.selected .event-single').clone())//克隆显示事件
                //$this.find('.events-list .event-single').eq(0).hide().slideDown();
                calcTotalDayAgain();
                calcScroll();
                // scrolltop after adding new event
                $this.find('.events-list').scrollTop(0);
                // form reset
                $this.find('.add-new > input[type="text"]').val(lAddEvent[settings.lang]).select();
                dataId++;
            });
            
            $close.on('click', function(){
                prevAddEvent(); 
            });
            
            删除事件
            $this.on('click', '.event-single .erase', function () {
                var thisDay = $this.find('.day.this-month.selected').attr('data-date');
                var dt = thisDay.replace("/", "").replace("/", "");
                if ($this.find('.day.'+dt+' .event-single').length == 1)
                {
                    $this.find('.day.'+dt+'').find('.' + dt + '').remove();
                    $this.find('.day.' + dt + ' .event-single').removeClass('have-event' + dt + '').attr('style', '');
                }
                alert('div[data-id=' + $(this).parents(".event-single").attr("data-id") + ']');
                $('div[data-id=' + $(this).parents(".event-single").attr("data-id") + ']').animate({ 'height': 0 }, function () {
                    var title = $(this).find('p').text();
                    var time = $(this).find('.details').find('.clock').text();
                    $(this).remove();
                    GN("delete",thisDay, time, title);
                    calcTotalDayAgain();
                    calcScroll();
                });
            });

        };

    }(jQuery));

});

