package com.travelplanner.ui.location

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
import com.travelplanner.models.Location
import io.reactivex.Single

fun Context.showLocationDialog(cityName: String, onLocationChosen: (Location) -> Unit){
    val v = LayoutInflater.from(this).inflate(R.layout.location_search_view, null, false)
    val recycler = v.findViewById<RecyclerView>(R.id.search_locations_recycler)
    val adapter = SearchLocationAdapter(){
        onLocationChosen(it)
    }

    getLocations(cityName){
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
private fun getLocations(cityName: String, onLocationsLoaded: (List<Location>) -> Unit ){
    val locationInfoApiService = DIContainer.locationInfoApiService
    locationInfoApiService.getLocation(cityName)
            .applySchedulers()
            .subscribe({
                onLocationsLoaded(it)
            },
            {
                Log.e("FlightViewModel", it.message.toString())
            })
}