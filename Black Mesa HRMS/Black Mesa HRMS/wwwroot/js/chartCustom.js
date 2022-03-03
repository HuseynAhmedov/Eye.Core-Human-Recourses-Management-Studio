


const IncomeChart = document.getElementById('IncomeChartjs').getContext('2d');
const GenderChart = document.getElementById('GenderChartjs').getContext('2d');
const SalaryByDateChart = document.getElementById('SalaryByDateChartjs').getContext('2d');
let monthViewBtnSalaryChartjs = document.getElementsByClassName("month-view-btn-ES")
let yearViewBtnSalaryChartjs = document.getElementsByClassName("year-view-btn-ES")

const IncomeChartConfig = new Chart(IncomeChart, {
    type: 'doughnut',
    data:{
        labels: [
            'Scientist',
            'Security',
            'Administration',
            'Maintenance',
        ],
        datasets: [{
          label: 'My First Dataset',
          data: [50, 10, 10, 30],
          backgroundColor: [
            'rgb(204, 0, 255)',
            'rgb(25, 0, 255)',
            'rgb(255, 0, 0)',
            'rgb(255, 196, 0)',
          ],
          hoverOffset: 4
        }]
    },
    options: {
        maintainAspectRatio: false
    }
});

const GenderChartConfig = new Chart(GenderChart, {
    type: 'pie',
    data: {
        labels: [
          'Women',
          'Men',
        ],
        datasets: [{
          data: [39, 412],
          backgroundColor: [
            'rgb(255, 99, 132)',
            'rgb(54, 162, 235)'
          ],
          hoverOffset: 4
        }]
    },
    options: {
        maintainAspectRatio: false
    }
});

var SalaryByMonthData = {
    labels: [
        'January',
        'February',
        'March',
        'April',
        'May',
        'June',
        'July',
        'August',
        'September',
        'February',
        'October',
        'November',
        'December',
    ],
    datasets: [{
      label: 'Scientist',
      data: [50, 59, 80, 81, 82, 70, 71],
      fill: false,
      borderColor: 'rgb(204, 0, 255)',
      tension: 0.1
    } , {
        label: 'Security',
        data: [10, 11, 13, 20, 19, 30, 22],
        fill: false,
        borderColor: 'rgb(25, 0, 255)',
        tension: 0.1
    } , {
        label: 'Administration',
        data: [5, 9, 12, 10, 12,16, 10],
        fill: false,
        borderColor: 'rgb(255, 0, 0)',
        tension: 0.1
    } , {
        label: 'Maintenance',
        data: [50, 44, 56, 54, 59, 60, 44],
        fill: false,
        borderColor: 'rgb(255, 196, 0)',
        tension: 0.1
    }],
};

var SalaryByYearData = {
    labels: [
        '2000',
        '2001',
        '2002',
        '2003',
        '2004',
        '2005',
        '2006',
        '2007',
        '2008',
        '2009',
    ],
    datasets: [{
      label: 'Scientist',
      data: [50, 59, 80, 81, 82, 70, 71],
      fill: false,
      borderColor: 'rgb(204, 0, 255)',
      tension: 0.1
    } , {
        label: 'Security',
        data: [10, 11, 13, 20, 19, 30, 22],
        fill: false,
        borderColor: 'rgb(25, 0, 255)',
        tension: 0.1
    } , {
        label: 'Administration',
        data: [5, 9, 12, 10, 12,16, 10],
        fill: false,
        borderColor: 'rgb(255, 0, 0)',
        tension: 0.1
    } , {
        label: 'Maintenance',
        data: [50, 44, 56, 54, 59, 60, 44],
        fill: false,
        borderColor: 'rgb(255, 196, 0)',
        tension: 0.1
    }],
};
const SalaryByDateChartConfig = new Chart(SalaryByDateChart, {
    type: 'line',
    data: {
        labels: [
            'January',
            'February',
            'March',
            'April',
            'May',
            'June',
            'July',
            'August',
            'September',
            'February',
            'October',
            'November',
            'December',
        ],
        datasets: [{
          label: 'Scientist',
          data: [50, 59, 80, 81, 82, 70, 71],
          fill: false,
          borderColor: 'rgb(204, 0, 255)',
          tension: 0.1
        } , {
            label: 'Security',
            data: [10, 11, 13, 20, 19, 30, 22],
            fill: false,
            borderColor: 'rgb(25, 0, 255)',
            tension: 0.1
        } , {
            label: 'Administration',
            data: [5, 9, 12, 10, 12,16, 10],
            fill: false,
            borderColor: 'rgb(255, 0, 0)',
            tension: 0.1
        } , {
            label: 'Maintenance',
            data: [50, 44, 56, 54, 59, 60, 44],
            fill: false,
            borderColor: 'rgb(255, 196, 0)',
            tension: 0.1
        }],
    },
});

monthViewBtnSalaryChartjs[0].addEventListener("click",function(ev)
{
    SalaryByDateChartConfig.data.datasets = SalaryByMonthData.datasets
    SalaryByDateChartConfig.data.datasets = SalaryByMonthData.datasets
    SalaryByDateChartConfig.data.labels = SalaryByMonthData.labels
    SalaryByDateChartConfig.update()
})

yearViewBtnSalaryChartjs[0].addEventListener("click",function(ev)
{
    SalaryByDateChartConfig.data.datasets = SalaryByYearData.datasets
    SalaryByDateChartConfig.data.labels = SalaryByYearData.labels
    SalaryByDateChartConfig.update()
})