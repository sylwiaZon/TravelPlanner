package com.travelplanner.ui.location

import android.app.AlertDialog
import android.content.Context
import android.view.LayoutInflater
import androidx.recyclerview.widget.LinearLayoutManager
import androidx.recyclerview.widget.RecyclerView
import com.travelplanner.R
import com.travelplanner.models.Location

fun Context.showLocationDialog(location: List<Location>, onLocationChosen: (Location) -> Unit){
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
    adapter.setData(location)
}