// Off-Canvas
(function ($) {
    'use strict';
    $(function () {
        $('[data-bs-toggle="offcanvas"]').on("click", function () {
            $('.sidebar-offcanvas').toggleClass('active')
        });
    });
})(jQuery);

// Hoverable Collapse
(function ($) {
    'use strict';
    //Open submenu on hover in compact sidebar mode and horizontal menu mode
    $(document).on('mouseenter mouseleave', '.sidebar .nav-item', function (ev) {
        var body = $('body');
        var sidebarIconOnly = body.hasClass("sidebar-icon-only");
        var sidebarFixed = body.hasClass("sidebar-fixed");
        if (!('ontouchstart' in document.documentElement)) {
            if (sidebarIconOnly) {
                if (sidebarFixed) {
                    if (ev.type === 'mouseenter') {
                        body.removeClass('sidebar-icon-only');
                    }
                } else {
                    var $menuItem = $(this);
                    if (ev.type === 'mouseenter') {
                        $menuItem.addClass('hover-open')
                    } else {
                        $menuItem.removeClass('hover-open')
                    }
                }
            }
        }
    });
})(jQuery);

// Template
(function ($) {
    'use strict';
    $(function () {
        var body = $('body');
        var contentWrapper = $('.content-wrapper');
        var scroller = $('.container-scroller');
        var footer = $('.footer');
        var sidebar = $('.sidebar');

        //Add active class to nav-link based on url dynamically
        //Active class can be hard coded directly in html file also as required

        function addActiveClass(element) {
            if (current === "") {
                //for root url
                if (element.attr('href').indexOf("index.html") !== -1) {
                    element.parents('.nav-item').last().addClass('active');
                    if (element.parents('.sub-menu').length) {
                        element.closest('.collapse').addClass('show');
                        element.addClass('active');
                    }
                }
            } else {
                //for other url
                if (element.attr('href').indexOf(current) !== -1) {
                    element.parents('.nav-item').last().addClass('active');
                    if (element.parents('.sub-menu').length) {
                        element.closest('.collapse').addClass('show');
                        element.addClass('active');
                    }
                    if (element.parents('.submenu-item').length) {
                        element.addClass('active');
                    }
                }
            }
        }

        var current = location.pathname.split("/").slice(-1)[0].replace(/^\/|\/$/g, '');
        $('.nav li a', sidebar).each(function () {
            var $this = $(this);
            addActiveClass($this);
        })

        $('.horizontal-menu .nav li a').each(function () {
            var $this = $(this);
            addActiveClass($this);
        })

        //Close other submenu in sidebar on opening any

        sidebar.on('show.bs.collapse', '.collapse', function () {
            sidebar.find('.collapse.show').collapse('hide');
        });


        //Change sidebar and content-wrapper height
        applyStyles();

        function applyStyles() {
            //Applying perfect scrollbar
            if (!body.hasClass("rtl")) {
                if ($('.settings-panel .tab-content .tab-pane.scroll-wrapper').length) {
                    const settingsPanelScroll = new PerfectScrollbar('.settings-panel .tab-content .tab-pane.scroll-wrapper');
                }
                if ($('.chats').length) {
                    const chatsScroll = new PerfectScrollbar('.chats');
                }
                if (body.hasClass("sidebar-fixed")) {
                    if ($('#sidebar').length) {
                        var fixedSidebarScroll = new PerfectScrollbar('#sidebar .nav');
                    }
                }
            }
        }

        $('[data-bs-toggle="minimize"]').on("click", function () {
            if ((body.hasClass('sidebar-toggle-display')) || (body.hasClass('sidebar-absolute'))) {
                body.toggleClass('sidebar-hidden');
            } else {
                body.toggleClass('sidebar-icon-only');
            }
        });

        //checkbox and radios
        $(".form-check label,.form-radio label").append('<i class="input-helper"></i>');

        //Horizontal menu in mobile
        $('[data-toggle="horizontal-menu-toggle"]').on("click", function () {
            $(".horizontal-menu .bottom-navbar").toggleClass("header-toggled");
        });
        // Horizontal menu navigation in mobile menu on click
        var navItemClicked = $('.horizontal-menu .page-navigation >.nav-item');
        navItemClicked.on("click", function (event) {
            if (window.matchMedia('(max-width: 991px)').matches) {
                if (!($(this).hasClass('show-submenu'))) {
                    navItemClicked.removeClass('show-submenu');
                }
                $(this).toggleClass('show-submenu');
            }
        })

        $(window).on("scroll", function () {
            if (window.matchMedia('(min-width: 992px)').matches) {
                var header = $('.horizontal-menu');
                if ($(window).scrollTop() >= 70) {
                    $(header).addClass('fixed-on-scroll');
                } else {
                    $(header).removeClass('fixed-on-scroll');
                }
            }
        });
        if ($("#datepicker-popup").length) {
            $('#datepicker-popup').datepicker({
                enableOnReadonly: true,
                todayHighlight: true,
            });
            $("#datepicker-popup").datepicker("setDate", "0");
        }

    });

    //check all boxes in order status 
    $("#check-all").on("click", function () {
        $(".form-check-input").prop('checked', $(this).prop('checked'));
    });

    // focus input when clicking on search icon
    $('#navbar-search-icon').on("click", function () {
        $("#navbar-search-input").on("focus", function () { });
    });

    $(window).on("scroll", function () {
        var scroll = $(window).scrollTop();

        //>=, not <=
        if (scroll >= 97) {
            //clearHeader, not clearheader - caps H
            $(".fixed-top").addClass("headerLight");
        }
        else {
            $(".fixed-top").removeClass("headerLight");
        }
    }); //missing );

})(jQuery);

// Settings
(function ($) {
    'use strict';
    $(function () {
        $(".nav-settings").on("click", function () {
            $("#right-sidebar").toggleClass("open");
        });
        $(".settings-close").on("click", function () {
            $("#right-sidebar,#theme-settings").removeClass("open");
        });

        $("#settings-trigger").on("click", function () {
            $("#theme-settings").toggleClass("open");
        });


        //background constants
        var navbar_classes = "navbar-danger navbar-success navbar-warning navbar-dark navbar-light navbar-primary navbar-info navbar-pink";
        var sidebar_classes = "sidebar-light sidebar-dark";
        var $body = $("body");

        //sidebar backgrounds
        $("#sidebar-light-theme").on("click", function () {
            $body.removeClass(sidebar_classes);
            $body.addClass("sidebar-light");
            $(".sidebar-bg-options").removeClass("selected");
            $(this).addClass("selected");
        });
        $("#sidebar-dark-theme").on("click", function () {
            $body.removeClass(sidebar_classes);
            $body.addClass("sidebar-dark");
            $(".sidebar-bg-options").removeClass("selected");
            $(this).addClass("selected");
        });


        //Navbar Backgrounds
        $(".tiles.primary").on("click", function () {
            $(".navbar").removeClass(navbar_classes);
            $(".navbar").addClass("navbar-primary");
            $(".tiles").removeClass("selected");
            $(this).addClass("selected");
        });
        $(".tiles.success").on("click", function () {
            $(".navbar").removeClass(navbar_classes);
            $(".navbar").addClass("navbar-success");
            $(".tiles").removeClass("selected");
            $(this).addClass("selected");
        });
        $(".tiles.warning").on("click", function () {
            $(".navbar").removeClass(navbar_classes);
            $(".navbar").addClass("navbar-warning");
            $(".tiles").removeClass("selected");
            $(this).addClass("selected");
        });
        $(".tiles.danger").on("click", function () {
            $(".navbar").removeClass(navbar_classes);
            $(".navbar").addClass("navbar-danger");
            $(".tiles").removeClass("selected");
            $(this).addClass("selected");
        });
        $(".tiles.light").on("click", function () {
            $(".navbar").removeClass(navbar_classes);
            $(".navbar").addClass("navbar-light");
            $(".tiles").removeClass("selected");
            $(this).addClass("selected");
        });
        $(".tiles.info").on("click", function () {
            $(".navbar").removeClass(navbar_classes);
            $(".navbar").addClass("navbar-info");
            $(".tiles").removeClass("selected");
            $(this).addClass("selected");
        });
        $(".tiles.dark").on("click", function () {
            $(".navbar").removeClass(navbar_classes);
            $(".navbar").addClass("navbar-dark");
            $(".tiles").removeClass("selected");
            $(this).addClass("selected");
        });
        $(".tiles.default").on("click", function () {
            $(".navbar").removeClass(navbar_classes);
            $(".tiles").removeClass("selected");
            $(this).addClass("selected");
        });
        $(".tiles.default").on("click", function () {
            $(".navbar").removeClass(navbar_classes);
            $(".tiles").removeClass("selected");
            $(this).addClass("selected");
        });

        $(".color-theme.default").on("click", function () {
            $(".color-theme.default").attr({
                "href": "https://www.bootstrapdash.com/demo/star-admin2-pro/template/demo/vertical-default-light/index.html",
                "title": "Light"
            });
        });
        $(".color-theme.dark").on("click", function () {
            $(".color-theme.dark").attr({
                "href": "https://www.bootstrapdash.com/demo/star-admin2-pro/template/demo/vertical-default-dark/index.html",
                "title": "Dark"
            });
        });
        $(".color-theme.brown").on("click", function () {
            $(".color-theme.brown").attr({
                "href": "https://www.bootstrapdash.com/demo/star-admin2-pro/template/demo/vertical-default-brown/index.html",
                "title": "Brown"
            });
        });
    });
})(jQuery);

// Todo List
(function ($) {
    'use strict';
    $(function () {
        var todoListItem = $('.todo-list');
        var todoListInput = $('.todo-list-input');
        $('.todo-list-add-btn').on("click", function (event) {
            event.preventDefault();

            var item = $(this).prevAll('.todo-list-input').val();

            if (item) {
                todoListItem.append("<li><div class='form-check'><label class='form-check-label'><input class='checkbox' type='checkbox'/>" + item + "<i class='input-helper'></i></label></div><i class='remove ti-close'></i></li>");
                todoListInput.val("");
            }

        });

        todoListItem.on('change', '.checkbox', function () {
            if ($(this).attr('checked')) {
                $(this).removeAttr('checked');
            } else {
                $(this).attr('checked', 'checked');
            }

            $(this).closest("li").toggleClass('completed');

        });

        todoListItem.on('click', '.remove', function () {
            $(this).parent().remove();
        });

    });
})(jQuery);

// JQuery Toast
(function ($) {
    showStatusMessage = function (status, heading, feedback) {
        'use strict';
        $.toast({
            icon: status,
            heading: heading,
            text: String(feedback),
            position: 'top-right',
            loaderBg: '#BEFF7F'
        })
    }
})(jQuery);

(function ($) {
    'use strict';
    $(function () {


        if ($("#modernRevenueGrowth").length) {
            const ctx = document.getElementById('modernRevenueGrowth');
            new Chart(ctx, {
                type: 'bar',
                data: {
                    labels: ["Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul"],
                    datasets: [{
                        label: 'Last week',
                        data: [50, 75, 100, 60, 70, 45, 90],
                        backgroundColor: "#00CDFF",
                        borderColor: [
                            '#00CDFF',
                        ],
                        borderWidth: 0,
                        fill: true, // 3: no fill
                        barPercentage: 0.4,
                    }]
                },
                options: {
                    responsive: true,
                    maintainAspectRatio: false,
                    elements: {
                        line: {
                            tension: 0,
                        },
                        point: {
                            radius: 0
                        }
                    },
                    tooltips: {
                        backgroundColor: 'rgba(31, 59, 179, 1)',
                    },
                    scales: {
                        y: {
                            border: {
                                display: false
                            },
                            display: true,
                            grid: {
                                min: 1,
                                display: true,
                                drawTicks: false,
                                color: "#F0F0F0",
                                zeroLineColor: '#F0F0F0',
                                drawBorder: false
                            },
                            ticks: {
                                beginAtZero: false,
                                autoSkip: true,
                                maxTicksLimit: 4,
                                color: "#6B778C",
                                font: {
                                    size: 10,
                                }
                            }
                        },
                        x: {
                            border: {
                                display: false
                            },
                            display: true,
                            grid: {
                                display: false,
                                drawTicks: false,
                                drawBorder: false
                            },
                            ticks: {
                                beginAtZero: false,
                                autoSkip: true,
                                maxTicksLimit: 7,
                                color: "#6B778C",
                                font: {
                                    size: 10,
                                }
                            }
                        }
                    },
                    plugins: {
                        legend: {
                            display: false,
                        }
                    }
                }
            });
        }

        if ($("#modernBubble").length) {
            const ctx = document.getElementById('modernBubble');
            new Chart(ctx, {
                type: 'bubble',
                data: {
                    labels: ["Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul"],
                    datasets: [{
                        label: 'Money send',
                        data: [{
                            x: 10,
                            y: 100,
                            r: 10
                        }, {
                            x: 20,
                            y: 500,
                            r: 15
                        }, {
                            x: 40,
                            y: 100,
                            r: 10
                        }, {
                            x: 55,
                            y: 200,
                            r: 10
                        }, {
                            x: 70,
                            y: 500,
                            r: 10
                        }, {
                            x: 0,
                            y: 600,
                            r: 0
                        }],
                        backgroundColor: 'rgb(30,59,179)'
                    }, {
                        label: 'Money Received',
                        data: [{
                            x: 10,
                            y: 300,
                            r: 5
                        }, {
                            x: 30,
                            y: 400,
                            r: 5
                        }, {
                            x: 60,
                            y: 410,
                            r: 10
                        }, {
                            x: 100,
                            y: 370,
                            r: 5
                        }, {
                            x: 110,
                            y: 0,
                            r: 0
                        }],
                        backgroundColor: 'rgb(99,171,253)',
                    }]
                },
                options: {
                    responsive: true,
                    maintainAspectRatio: false,
                    elements: {
                        line: {
                            tension: 0,
                        },
                        point: {
                            radius: 0
                        }
                    },
                    tooltips: {
                        backgroundColor: 'rgba(31, 59, 179, 1)',
                    },
                    scales: {
                        y: {
                            border: {
                                display: false
                            },
                            display: true,
                            grid: {
                                min: 1,
                                display: true,
                                drawTicks: false,
                                color: "#F0F0F0",
                                zeroLineColor: '#F0F0F0',
                                drawBorder: false
                            },
                            ticks: {
                                beginAtZero: false,
                                autoSkip: true,
                                maxTicksLimit: 4,
                                color: "#6B778C",
                                font: {
                                    size: 10,
                                }
                            }
                        },
                        x: {
                            border: {
                                display: false
                            },
                            display: true,
                            grid: {
                                display: false,
                                drawTicks: false,
                                drawBorder: false
                            },
                            ticks: {
                                beginAtZero: false,
                                autoSkip: true,
                                maxTicksLimit: 7,
                                color: "#6B778C",
                                font: {
                                    size: 10,
                                }
                            }
                        }
                    },
                    plugins: {
                        legend: {
                            display: false,
                        }
                    }
                },
                plugins: [{
                    afterDatasetUpdate: function (chart, args, options) {
                        const chartId = chart.canvas.id;
                        var i;
                        const legendId = `${chartId}-legend`;
                        const ul = document.createElement('ul');
                        for (i = 0; i < chart.data.datasets.length; i++) {
                            ul.innerHTML += `
                  <li>
                    <span style="background-color: ${chart.data.datasets[i].backgroundColor}"></span>
                    ${chart.data.datasets[i].label}
                  </li>
                `;
                        }
                        return document.getElementById(legendId).appendChild(ul);
                    }
                }]
            });
        }


        if ($("#moneyFlow").length) {
            const ctx = document.getElementById('moneyFlow');
            var graphGradient = document.getElementById("moneyFlow").getContext('2d');
            var moneyFlowGradientBg = graphGradient.createLinearGradient(10, 10, 1, 160);
            moneyFlowGradientBg.addColorStop(1, 'rgba(30, 59, 179, 0)');
            moneyFlowGradientBg.addColorStop(0, 'rgba(30, 59, 179, 0.3)');

            new Chart(ctx, {
                type: 'line',
                data: {
                    labels: ["jan", "feb", "mar", "apr", "may", "jun", "july", "aug", "sep", "oct", "nov", "dec"],
                    datasets: [{
                        label: 'Last week',
                        data: [20000, 50000, 30000, 80000, 60000, 55000, 45000, 60000, 35000, 50000, 55000, 40000],
                        backgroundColor: moneyFlowGradientBg,
                        borderWidth: 2,
                        pointBorderWidth: 0,
                        borderColor: [
                            '#1E3BB3',
                        ],
                        fill: true, // 3: no fill   
                    }]
                },
                options: {
                    responsive: true,
                    maintainAspectRatio: false,
                    elements: {
                        line: {
                            tension: 0.4,
                        }
                    },
                    tooltips: {
                        backgroundColor: 'rgba(31, 59, 179, 1)',
                    },

                    scales: {
                        y: {
                            border: {
                                display: false
                            },
                            grid: {
                                display: true,
                                drawTicks: false,
                                color: "#F0F0F0",
                                zeroLineColor: '#F0F0F0',
                                drawBorder: false
                            },
                            ticks: {
                                beginAtZero: false,
                                autoSkip: true,
                                maxTicksLimit: 4,
                                color: "#6B778C",
                                font: {
                                    size: 10,
                                }
                            }
                        },
                        x: {
                            border: {
                                display: false
                            },
                            grid: {
                                display: false,
                                drawTicks: false,
                                drawBorder: false
                            },
                            ticks: {
                                beginAtZero: false,
                                autoSkip: true,
                                maxTicksLimit: 7,
                                color: "#6B778C",
                                font: {
                                    size: 10,
                                }
                            }
                        }
                    },
                    plugins: {
                        legend: {
                            display: false,
                        }
                    }
                },
            });
        }


        if ($("#modernChartliability").length) {
            const doughnutChartCrmCanvas = document.getElementById('modernChartliability');
            new Chart(doughnutChartCrmCanvas, {
                type: 'doughnut',
                data: {
                    datasets: [{
                        data: [50, 20, 30],
                        backgroundColor: [
                            "#4DA761",
                            "#00CDFF",
                            "#EE5E51",
                        ],
                        borderColor: [
                            "#fff",
                            "#fff",
                            "#fff",
                        ],
                    }],

                    // These labels appear in the legend and in the tooltips when hovering different arcs
                    labels: [
                        'Current',
                        'New',
                        'Pending',
                    ]
                },
                options: {
                    cutout: 40,
                    animationEasing: "easeOutBounce",
                    animateRotate: true,
                    animateScale: false,
                    showScale: true,
                    plugins: {
                        legend: {
                            display: false,
                        }
                    },
                    responsive: true,
                    maintainAspectRatio: true,
                    tooltips: {
                        backgroundColor: '#fff',
                        titleFontSize: 14,
                        titleFontColor: '#0B0F32',
                        bodyFontColor: '#737F8B',
                        bodyFontSize: 11,
                        displayColors: false
                    }
                },
                plugins: [{
                    afterDatasetUpdate: function (chart, args, options) {
                        const chartId = chart.canvas.id;
                        var i;
                        const legendId = `${chartId}-legend`;
                        const ul = document.createElement('ul');
                        for (i = 0; i < chart.data.datasets[0].data.length; i++) {
                            ul.innerHTML += `
                  <li>
                    <span style="background-color: ${chart.data.datasets[0].backgroundColor[i]}"></span>
                    ${chart.data.labels[i]} 
                  </li>
                `;
                        }
                        return document.getElementById(legendId).appendChild(ul);
                    }
                }]
            });
        }
    });


})(jQuery);