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
    val dialog = AlertDialog.Builder(this).run{
        setView(v)
        setNegativeButton("Cancel") { _, _ -> }
        show()
    }
    val adapter = SearchLocationAdapter(){
        onLocationChosen(it)
        dialog.dismiss()
    }

    recycler.adapter = adapter
    recycler.layoutManager = LinearLayoutManager(this)
    getLocations(cityName){
        adapter.setData(it)
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
                Log.e("showLocationDialog", it.message.toString())
            })
}