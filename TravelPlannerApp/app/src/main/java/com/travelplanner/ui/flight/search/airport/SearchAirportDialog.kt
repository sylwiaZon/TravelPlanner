package com.travelplanner.ui.flight.search.airport

import android.annotation.SuppressLint
import android.app.AlertDialog
import android.content.Context
import android.util.Log
import android.view.LayoutInflater
import androidx.recyclerview.widget.LinearLayoutManager
import androidx.recyclerview.widget.RecyclerView
import com.travelplanner.R
import com.travelplanner.api.applySchedulers
import com.travelplanner.di.DIContainer
import com.travelplanner.models.Airport
import com.travelplanner.models.Location

fun Context.showAirportDialog(latitude: String, longitude: String, onAirportChosen: (Airport) -> Unit){
    val v = LayoutInflater.from(this).inflate(R.layout.airport_search_view, null, false)
    val recycler = v.findViewById<RecyclerView>(R.id.search_airports_recycler)
    val adapter = SearchAirportAdapter(){
        onAirportChosen(it)
    }

    getLocations(latitude, longitude){
        adapter.setData(it)
        recycler.adapter = adapter
        recycler.layoutManager = LinearLayoutManager(this)
        AlertDialog.Builder(this).apply{
            setView(v)
            setNegativeButton("Cancel") { _, _ -> }
            show()
        }
    }
}

@SuppressLint("CheckResult")
private fun getLocations(latitude: String, longitude: String, onLocationsLoaded: (List<Airport>) -> Unit ){
    val flightApiService = DIContainer.flightsApiService
    flightApiService.getNearestAirports(latitude, longitude)
            .applySchedulers()
            .subscribe({
                onLocationsLoaded(it)
            },
            {
                Log.e("AirportViewModel", it.message.toString())
            })
}