package com.travelplanner.ui.dayPlan

import android.app.DatePickerDialog
import android.content.Context
import java.time.LocalDate

fun Context.showDayPlanDatePickerDialog(onDateChosen: (LocalDate) -> Unit){
    val datePickerDialog = DatePickerDialog(this).run{
        setOnDateSetListener { view, year, month, dayOfMonth -> onDateChosen(LocalDate.of(year, month + 1, dayOfMonth))}
        show()
    }
}
