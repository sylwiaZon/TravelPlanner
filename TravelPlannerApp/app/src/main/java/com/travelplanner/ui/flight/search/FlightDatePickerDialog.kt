package com.travelplanner.ui.flight.search

import android.app.DatePickerDialog
import android.content.Context
import java.time.LocalDate

fun Context.showFlightDatePickerDialog(onDateChosen: (LocalDate) -> Unit){
    val datePickerDialog = DatePickerDialog(this).run{
        setOnDateSetListener { view, year, month, dayOfMonth -> onDateChosen(LocalDate.of(year, month + 1, dayOfMonth))}
        show()
    }
}
