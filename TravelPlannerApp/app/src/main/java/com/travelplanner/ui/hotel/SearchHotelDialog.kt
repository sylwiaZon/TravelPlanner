package com.travelplanner.ui.hotel

import android.annotation.SuppressLint
import android.app.AlertDialog
import android.content.Context
import android.util.Log
import android.view.LayoutInflater
import android.widget.Toast
import androidx.recyclerview.widget.LinearLayoutManager
import androidx.recyclerview.widget.RecyclerView
import com.travelplanner.R
import com.travelplanner.di.DIContainer
import com.travelplanner.models.Flight
import com.travelplanner.models.Hotel
import com.travelplanner.utils.applySchedulers
import java.time.LocalDate
import java.time.format.DateTimeFormatter

fun Context.showSearchHotelDialog(cityName: String, onHotelChosen: (Hotel) -> Unit){
    val v = LayoutInflater.from(this).inflate(R.layout.hotel_search_view, null, false)
    val recycler = v.findViewById<RecyclerView>(R.id.search_hotel_recycler)
    val dialog = AlertDialog.Builder(this).run{
        setView(v)
        setNegativeButton("Cancel") { _, _ -> }
        show()
    }
    val adapter = SearchHotelAdapter(){
        onHotelChosen(it)
        dialog.dismiss()
    }

    recycler.adapter = adapter
    recycler.layoutManager = LinearLayoutManager(this)
    getHotels(cityName) {
        if(it.isNotEmpty()) adapter.setData(it)
        else {
            Toast.makeText(this, "There is nothing to show. Try another criteria.", Toast.LENGTH_SHORT).show()
        }
    }
}

@SuppressLint("CheckResult")
private fun getHotels(cityName: String, onHotelsLoaded: (List<Hotel>) -> Unit ){
    val flightApiService = DIContainer.hotelsApiService
    flightApiService.getHotels(cityName)
            .applySchedulers()
            .subscribe({
                onHotelsLoaded(it)
            },
            {
                Log.e("SearchFlightDialog", it.message.toString())
            })
}