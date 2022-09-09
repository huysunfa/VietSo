

// DxDataGrid - Require DevExtreme
var BASIC_GRID_OPTION = {

    dataSource: [],
    //keyExpr: "ID",
    showRowLines: true,
    showColumnHeaders: true,
    showBorders: true,
    allowColumnResizing: true,
    hoverStateEnabled: true,
    columnAutoWidth: true,
    noDataText: "Không tìm thấy dữ liệu",
    allowColumnReordering: true,
    rowAlternationEnabled: false,
    wordWrapEnabled: false,
    columnChooser: {
        enabled: true,
        mode: "select"
    },
   
    groupPanel: {
        emptyPanelText: "Kéo tiêu đề cột vào đây để nhóm dữ liệu",
        visible: true
    },
    paging: {
        enabled: true,
        pageSize: 20
    },
    pager: {
        showPageSizeSelector: true,
        allowedPageSizes: [20, 50, 100, 200],
        showNavigationButtons: true
    },
    selection: {
        mode: "multiple",
        //  showCheckBoxesMode: "always",
        allowSelectAll: true
    },
    loadPanel: {
        enabled: true,
        height: 90,
        shading: true,
        showIndicator: true,
        showPane: true,
        text: "Đang load dữ liệu...",
        width: 200,
        delay: 0
    },
    filterRow: {
        visible: true,
        applyFilter: "auto"
    },
    scrolling: {
        mode: "standard",
        scrollByContent: true
    },
    headerFilter: {
        visible: true
    },

    //filterPanel: { visible: true },
    //summary: {
    //    totalItems: [
    //        {
    //            column: "STT",
    //            summaryType: "count"
    //        }
    //    ]
    //},
    export: {
        enabled: true,
        fileName: "Result " + document.title,
        allowExportSelectedData: true
    },
    editing: {
        mode: "row",
        allowAdding: false,
        allowUpdating: false,
        allowDeleting: false,
        useIcons: true,
    },
    onCellPrepared: function (e) {
        if (e.rowType == "header") {
            e.cellElement.css("font-weight", "bold");
            // e.cellElement.css("background-color", "#6915cf");
        }
        e.cellElement.css("text-align", "left");
        e.cellElement.css("vertical-align", "middle");
    },
    onContentReady: function (e) {
        e.component.columnOption("command:edit", "width", 60);

        if (e.component.shouldSkipNextReady) {
            e.component.shouldSkipNextReady = false;
        }
        else {
            e.component.shouldSkipNextReady = true;
            e.component.columnOption("command:select", "width", 30);
            e.component.updateDimensions();
        }
        //if (e.element.find(".dx-datagrid-header-panel").html().indexOf('textstyle_1') == -1) {
        //    e.element.find(".dx-datagrid-header-panel").append('<div style="    font-size: 24px;color:red" class="textstyle_1"><B>' + document.title + '</B></div>');
        //}

    },
    onRowRemoving: function (e) {
        var removeUrl = e.component.option('removeUrl');
        $.ajax({
            url: removeUrl,
            type: 'POST',
            dataType: 'json',
            async: false,
            data: { item: e.data },
            success: function (response) {
                if (response.result == "Success") {

                    DevExpress.ui.notify('Xóa dữ liệu thành công ', 'success', 1500)
                }
                else {
                    e.cancel = true;
                    DevExpress.ui.notify(response.message, 'error', 1500)
                }
            },
            error: function (err) {
                DevExpress.ui.notify('Error', 'Error', 1500)
                e.cancel = true;
            }
        });
    },
    onRowUpdating: function (e) {
        var updateUrl = e.component.option('updateUrl');
        var newItem = {};
        newItem = Object.assign(newItem, e.oldData);//   Object.create(e.oldData);
        var changedProperty = Object.keys(e.newData);
        $.each(changedProperty, function (i, prop) {
            newItem[prop] = e.newData[prop];
        })
        var newItemProperty = Object.keys(newItem);
        $.each(newItemProperty, function (i, prop) {
            if (newItem[prop] instanceof Date) {
                newItem[prop] = newItem[prop].toISOString();
            }
        })
        $.ajax({
            url: updateUrl,
            type: 'POST',
            dataType: 'json',
            async: false,
            data: { item: newItem },
            success: function (response) {
                if (response.result == "Success") {

                    DevExpress.ui.notify('Cập nhật dữ liệu thành công ', 'success', 1500)
                }
                else {
                    e.cancel = true;
                    DevExpress.ui.notify(response.message, 'error', 1500)
                }
            },
            error: function (err) {
                DevExpress.ui.notify('Error', 'Error', 1500)
                e.cancel = true;
            }
        });
    },
    onRowInserting: function (e) {
        var insertUrl = e.component.option('insertUrl');
        $.ajax({
            url: insertUrl,
            type: 'POST',
            dataType: 'json',
            async: false,
            data: { item: e.data },
            success: function (response) {
                if (response.result == "Success") {
                    var listDateTimeProperty = findDateTimeProperty(response.data);
                    if (listDateTimeProperty.length > 0) {
                        $.each(listDateTimeProperty, function (i, prop) {
                            response.data[prop] = FromJsonToDate(response.data[prop]);
                        })
                    }
                    e.data = response.data;
                    DevExpress.ui.notify('Thêm dữ liệu thành công ', 'success', 1500)
                }
                else {
                    e.cancel = true;
                    DevExpress.ui.notify(response.message, 'error', 1500)
                }
            },
            error: function (err) {
                DevExpress.ui.notify('Error', 'Error', 1500)
                e.cancel = true;
            }
        });
    },
};

//LoadBasicGridOption($('#gridTest'));
//LoadGridData($('#gridTest'), '/Register/GetRegister')
var PROPERTY_CAPTION = {};

function CreateColumns(templateData) {
    var columnsData = [];
    for (var prop in templateData) {
        var newColumn = {
            dataField: prop,
            caption: PROPERTY_CAPTION[prop] ? PROPERTY_CAPTION[prop] : prop,
        };
        if (templateData[prop] instanceof Date) {
            newColumn.dataType = "date"
            if (templateData[prop].getHours() == 0 && templateData[prop].getMinutes() == 0 && templateData[prop].getSeconds() == 0) {
                newColumn.format = {
                    type: "yyyy-MM-dd"
                }
            } else {
                newColumn.format = {
                    type: "yyyy-MM-dd hh:mm:ss"
                }
            }

        }
        else
            if (!isNaN(templateData[prop])) {
                // newColumn.dataType = "number";
                if ((templateData[prop] % 1) != 0) {
                    newColumn.format = {
                        type: "fixedPoint",
                        precision: 0
                    }
                }
            }
            else
                if (typeof (templateData[prop]) === "string" && checkDate(templateData[prop])) {
                    var newDate = new Date(Date.parse(templateData[prop]))
                    newColumn.dataType = "date"
                    if (newDate.getHours() == 0 && newDate.getMinutes() == 0 && newDate.getSeconds() == 0) {
                        newColumn.format = {
                            type: "yyyy-MM-dd"
                        }
                    } else {
                        newColumn.format = {
                            type: "yyyy-MM-dd hh:mm:ss"
                        }
                    }
                }
        columnsData.push(newColumn);
    }
    columnsData.unshift({
        caption: "STT",
        cellTemplate: function (a, b) {
            a.append((b.rowIndex + 1));
        }
    });
    return columnsData;
}

function checkDate(input) {
    input = input.substring(0, 10);
    input = input.split('-');
    if (input.length != 3) {
        return false;
    }
    var year = input[0];
    var month = input[1];
    var day = input[2];
    if (isNaN(year) || year < 2000 || year > 2050) {
        return false;
    }
    if (isNaN(month) || month > 12 || month < 1) {
        return false;
    }
    if (isNaN(day) || day > 31 || day < 1) {
        return false;
    }
    var val = isNaN(input);
    return val;
}

function LoadBasicGridOption(newgrid, title) {
    var grid = $(newgrid);

   
    if (title == null || title == undefined) {
        title = document.title;
    }
    grid.dxDataGrid(BASIC_GRID_OPTION);
    grid.find(".dx-toolbar-items-container .dx-toolbar-before").append('<B style="    font-size: 24px;color:#009688">' + title + '</B>');

}

function LoadGridData_AutoColumn(gridID, URL, columnsData = null, async = true, runfunction = null) {
    var gridName = $(gridID);

    $.ajax({
        url: URL,
        type: 'POST',
        dataType: 'json',
        async: async,
        success: function (response) {
            if (response.result == "Success") { //

                var isJson = false;
                if (typeof (response.data) === "string" && response.data != "") {
                    response.data = JSON.parse(`` + response.data + ``);
                    isJson = true;
                }
                if (response.data.length == 0) {
                    return;
                }
                var templateData = {};
                templateData = Object.assign(templateData, response.data[0]);
                $.each(Object.keys(templateData), function (i, item) {
                    if (templateData[item] == null) {
                        var prop = response.data.filter(x => x[item] != null)[0];
                        if (prop != null) {
                            templateData[item] = prop[item];
                        }
                    }
                });

                if (!isJson) {
                    var listDateTimeProperty = findDateTimeProperty(templateData);
                    if (listDateTimeProperty.length > 0) {
                        $.each(response.data, function (i, item) {
                            for (i = 0; i < listDateTimeProperty.length; i++) {
                                item[listDateTimeProperty[i]] = FromJsonToDate(item[listDateTimeProperty[i]]);
                            }
                        })
                        for (i = 0; i < listDateTimeProperty.length; i++) {
                            templateData[listDateTimeProperty[i]] = FromJsonToDate(templateData[listDateTimeProperty[i]]);
                        }
                    }
                }
                else {

                }
                if (columnsData == null) {
                    gridName.dxDataGrid("instance").option("columns", CreateColumns(templateData));
                }
                else {
                    gridName.dxDataGrid("instance").option("columns", columnsData);
                }
                gridName.dxDataGrid("instance").option("dataSource", response.data);
                // gridName.dxDataGrid("instance").refresh();
                if (runfunction != null) {
                    runfunction();
                }

            }
        },
        error: function (err) {
            DevExpress.ui.notify("Error", "error", 2000);
        }
    });
}
function findDateTimeProperty(object) {
    var listDateTimeProperty = [];
    for (var prop in object) {
        if ((typeof object[prop] == "string") && (object[prop].includes('/Date('))) {
            listDateTimeProperty.push(prop);
        }
    }
    return listDateTimeProperty;
}














// Button Function - Require Font-Awesome
function loadingButton(element) {
    element.append(`  <i class="fa fa-spinner fa-spin"></i>`);
}

function endLoadingButton(element) {
    element.find('.fa-spin').remove();
}



// Add Array Prototype - Require Jquery
function SelectColumn(arr, n) {
    return arr.map(x => x[n]);
}
// Sample Unique
//var unique = myArray.filter((v, i, a) => a.indexOf(v) === i); 







// Json Date to JS Date
function FromJsonToDate(value) {
    if (value != null) {
        return new Date(parseInt(value.replace('/Date(', '')));
    }
    return;
}


//Sample MasterDetail 
var masterDetailSample = {
    autoExpandAll: false,
    enabled: true,
    template: function (container, option) {
        var staffID = option.data.StaffID;
        container.append(`<div id="grid` + staffID + `"></div>`);
        LoadBasicGridOption($('#grid' + staffID + ''));
        LoadGridData($('#grid' + staffID + ''), '/Supplier/GetUserAnswerData?staffID=' + staffID);
    }
};

// Sample ContextMenu : onContextMenuPreparing
var contextMenuSample = function (e) {
    if (e.row != null) {
        if (e.row.rowType == "data") {
            let boxSubmenuItems = [
                {
                    text: 'Xem chi tiết',
                    icon: 'search',
                    onItemClick: function (ev) {
                    }
                },
            ];
            e.items = boxSubmenuItems;
        }

    }
};


// Sample ToolBar
var onToolbarPreparingIMP = function (e) {
    var toolbarItems = e.toolbarOptions.items;

    e.toolbarOptions.items.unshift(
        {
            location: "center",
            widget: "dxButton",
            options: {
                icon: "save",
                hint: "Save Box JHK Use Data",
                text: "Save Box JHK Use Data",
                onClick: function (ev) {
                    SaveBoxJHKUse(e);
                }
            }
        },
    );
};

// Date Compare
function DateCompare(date1, date2) {
    if (date1 == null || date2 == null || !(date1 instanceof Date) || !(date2 instanceof Date)) return;
    if (date1.getFullYear() == date2.getFullYear() && date1.getMonth() == date2.getMonth() && date1.getDate() == date2.getDate()) return 0; //date1 == date 2
    if (date1.getTime() > date2.getTime()) return 1; // date1 >  date 2
    return -1;
}



// Timer Countdown
function startTimerSample(duration, display, func) {
    var timer = duration, minutes, seconds;
    setInterval(function () {
        minutes = parseInt(timer / 60, 10);
        seconds = parseInt(timer % 60, 10);

        minutes = minutes < 10 ? "0" + minutes : minutes;
        seconds = seconds < 10 ? "0" + seconds : seconds;

        display.text(minutes + " phút " + seconds + " giây ");

        if (--timer < 0) {
            timer = duration;
            // Run Function
            func();
        }
    }, 1000);
}

//jQuery(function ($) {
//    var fiveMinutes = 60 * 5,
//        display = $('#time');
//    startTimer(fiveMinutes, display);
//});



//Require CSS
//.full-screen-view{
//    position:fixed;
//    left:0;
//    top:0;
//    z-index:99999;
//}

function FullScreenView(newgrid, enable = true) {
    var grid = $(newgrid);
    if (enable) {
        grid.dxDataGrid('instance').option('width', "100%");
        grid.dxDataGrid('instance').option('height', "100%");
        grid.addClass('full-screen-view')
    }
    else {
        grid.dxDataGrid('instance').option('width', "100%");
        grid.dxDataGrid('instance').option('height', window.innerHeight * 0.8);
        grid.removeClass('full-screen-view')
    }
}

var Fullscreenbutton = [
    {
        location: "after",
        widget: "dxButton",
        options: {
            icon: "fa fa-expand",
            hint: "Full Screen",
            text: "Full Screen",
            onClick: function (ev) {
                FullScreenView(e.element, true);
            }
        }
    },
    {
        location: "after",
        widget: "dxButton",
        options: {
            icon: "fa fa-compress",
            hint: "Minimize",
            text: "Minimize",
            onClick: function (ev) {
                FullScreenView(e.element, false);
            }
        }
    }];



function parseDate(str) {
    var mdy = str.split('-');
    return new Date(mdy[0], mdy[1] - 1, mdy[2]);
}

function datediff(first, second) {
    // Take the difference between the dates and divide by milliseconds per day.
    // Round to nearest whole number to deal with DST.
    return Math.round((second - first) / (1000 * 60 * 60 * 24));
}


// Post Grid DataSource To URL
function SaveData(e, URL, element) {
    var dataSource = e.component.option('dataSource');
    if (dataSource.length == 0) {
        alert('Không có dữ liệu , xin kiểm tra lại !!!!!!!');
        return;
    }
    var listDateTimeProperty = FindDateProperty(dataSource[0]);
    if (listDateTimeProperty.length > 0) {
        $.each(dataSource, function (i, item) {
            for (i = 0; i < listDateTimeProperty.length; i++) {
                item[listDateTimeProperty[i]] = item[listDateTimeProperty[i]].toISOString();
            }
        })
    }
    loadingButton(element);
    $.ajax({
        url: URL,
        type: "POST",
        data: { listData: dataSource },
        success: function (response) {
            if (response.result == "Success") {
                gridNewCostDown.option('dataSource', []);
                DevExpress.ui.notify("Success", "success", 5000);
            }
            else {
                alert(response.message);
            }
            $("#excelinput").val('');
            endLoadingButton(element);
        },
        error: function (err) {
            DevExpress.ui.notify("Error!!!!", "error", 5000);
            $("#excelinput").val('');
            endLoadingButton(element);
        }
    })
}


