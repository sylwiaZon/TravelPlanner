package com.travelplanner.ui.flight.search

import android.annotation.SuppressLint
import android.app.AlertDialog
import android.content.Context
import android.util.Log
import android.view.LayoutInflater
import android.widget.Toast
import androidx.recyclerview.widget.LinearLayoutManager
import androidx.recyclerview.widget.RecyclerView
import com.travelplanner.R
import com.travelplanner.api.applySchedulers
import com.travelplanner.di.DIContainer
import com.travelplanner.models.Airport
import com.travelplanner.models.Flight
import java.time.LocalDate
import java.time.format.DateTimeFormatter

fun Context.showSearchFlightDialog(origin: String, destination: String, date: LocalDate, onFlightChosen: (Flight) -> Unit){
    val v = LayoutInflater.from(this).inflate(R.layout.flight_search_view, null, false)
    val recycler = v.findViewById<RecyclerView>(R.id.search_flight_recycler)
    val dialog = AlertDialog.Builder(this).run{
        setView(v)
        setNegativeButton("Cancel") { _, _ -> }
        show()
    }
    val adapter = SearchFlightAdapter(){
        onFlightChosen(it)
        dialog.dismiss()
    }

    recycler.adapter = adapter
    recycler.layoutManager = LinearLayoutManager(this)
    getFlights(origin, destination, date) {
        if(it.isNotEmpty()) adapter.setData(it)
        else {
            Toast.makeText(this, "There is nothing to show. Try another criteria.", Toast.LENGTH_SHORT).show()
        }
    }
}

@SuppressLint("CheckResult")
private fun getFlights(origin: String, destination: String, date: LocalDate, onFlightsLoaded: (List<Flight>) -> Unit ){
    val flightApiService = DIContainer.flightsApiService
    val formatter = DateTimeFormatter.ofPattern("yyyy-MM-dd")
    flightApiService.getFlights(origin, destination, date.format(formatter))
            .applySchedulers()
            .subscribe({
                onFlightsLoaded(it)
            },
            {
                Log.e("SearchFlightDialog", it.message.toString())
            })
}