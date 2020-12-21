package com.travelplanner.ui.flight.search.airport

import android.annotation.SuppressLint
import android.app.AlertDialog
import android.content.Context
import android.util.Log
import android.view.LayoutInflater
import androidx.recyclerview.widget.LinearLayoutManager
import androidx.recyclerview.widget.RecyclerView
import com.travelplanner.R
import com.travelplanner.di.DIContainer
import com.travelplanner.models.Airport
import com.travelplanner.models.Location
import com.travelplanner.ui.location.SearchLocationAdapter
import com.travelplanner.ui.location.showLocationDialog
import com.travelplanner.utils.applySchedulers

fun Context.showAirportDialog(latitude: Float, longitude: Float, onAirportChosen: (Airport) -> Unit){
    val v = LayoutInflater.from(this).inflate(R.layout.airport_search_view, null, false)
    val recycler = v.findViewById<RecyclerView>(R.id.search_airports_recycler)
    val dialog = AlertDialog.Builder(this).run{
        setView(v)
        setNegativeButton("Cancel") { _, _ -> }
        show()
    }
    val adapter = SearchAirportAdapter(){
        onAirportChosen(it)
        dialog.dismiss()
    }

    recycler.adapter = adapter
    recycler.layoutManager = LinearLayoutManager(this)
    getAirports(latitude, longitude) {
        adapter.setData(it)
    }
}

@SuppressLint("CheckResult")
private fun getAirports(latitude: Float, longitude: Float, onLocationsLoaded: (List<Airport>) -> Unit ){
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