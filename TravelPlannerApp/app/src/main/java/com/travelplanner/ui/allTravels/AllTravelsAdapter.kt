package com.travelplanner.ui.allTravels

import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import android.widget.TextView
import androidx.recyclerview.widget.RecyclerView
import com.bumptech.glide.Glide
import com.travelplanner.R
import com.travelplanner.models.Travel
import java.text.SimpleDateFormat
import java.time.format.DateTimeFormatter
import java.time.format.FormatStyle

class AllTravelsAdapter : RecyclerView.Adapter<AllTravelsAdapter.ViewHolder>() {
    class ViewHolder(itemView: View) : RecyclerView.ViewHolder(itemView) {

    }

    private var travelsList:  List<Travel> = emptyList()

    override fun onCreateViewHolder(parent: ViewGroup, viewType: Int): ViewHolder {
       val itemView: View = LayoutInflater.from(parent.context).inflate(R.layout.item_all_travels, parent, false)
       return ViewHolder(itemView)
    }

    override fun getItemCount(): Int {
        return travelsList.size
    }

    override fun onBindViewHolder(holder: ViewHolder, position: Int) {
        val holderView = holder.itemView
        val formatter = DateTimeFormatter.ofLocalizedDate(FormatStyle.LONG)
        holderView.findViewById<TextView>(R.id.item_destination).text = travelsList[position].travelDestination.city
        val datesString = travelsList[position].arrivalDate.format(formatter) + " - " + travelsList[position].departureDate.format(formatter)
        holderView.findViewById<TextView>(R.id.item_dates).text = datesString
        Glide
                .with(holderView.context)
                .load(travelsList[position].photoUrl)
                .into(holderView.findViewById(R.id.item_image));
    }

    public fun setData(data: List<Travel>){
        travelsList = data
        notifyDataSetChanged()
    }
}