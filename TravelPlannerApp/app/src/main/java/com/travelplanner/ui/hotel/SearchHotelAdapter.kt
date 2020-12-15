package com.travelplanner.ui.hotel

import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import android.widget.TextView
import androidx.recyclerview.widget.RecyclerView
import com.google.android.material.card.MaterialCardView
import com.travelplanner.R
import com.travelplanner.models.Flight
import com.travelplanner.models.Hotel
import java.time.format.DateTimeFormatter

class  SearchHotelAdapter(val onHotelChosen: (Hotel) -> Unit): RecyclerView.Adapter<SearchHotelAdapter.ViewHolder>() {
    class ViewHolder(itemView: View) : RecyclerView.ViewHolder(itemView) {}

    private var hotelsList: List<Hotel> = emptyList()

    override fun onCreateViewHolder(parent: ViewGroup, viewType: Int): ViewHolder {
        val itemView: View = LayoutInflater.from(parent.context).inflate(R.layout.item_search_flight, parent, false)
        return ViewHolder(itemView)
    }

    override fun getItemCount(): Int {
        return hotelsList.size
    }

    override fun onBindViewHolder(holder: ViewHolder, position: Int) {
        val v = holder.itemView
        val hotelName = v.findViewById<TextView>(R.id.search_hotel_name)
        val hotelCard = v.findViewById<TextView>(R.id.search_hotel_card)
        hotelName.text = hotelsList[position].name
        hotelCard.setOnClickListener{
            onHotelChosen(hotelsList[position])
        }
    }

    public fun setData(data: List<Hotel>) {
        hotelsList = data
        notifyDataSetChanged()
    }
}