package com.travelplanner.ui.hotel

import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import android.widget.TextView
import androidx.recyclerview.widget.LinearLayoutManager
import androidx.recyclerview.widget.RecyclerView
import com.travelplanner.R
import com.travelplanner.models.HotelTransport

class HotelAdapter() : RecyclerView.Adapter<HotelAdapter.ViewHolder>() {
    class ViewHolder(itemView: View) : RecyclerView.ViewHolder(itemView) {

    }

    private var transportList: List<HotelTransport> = emptyList()

    override fun onCreateViewHolder(parent: ViewGroup, viewType: Int): ViewHolder {
        val itemView: View = LayoutInflater.from(parent.context).inflate(R.layout.item_transport_category, parent, false)
        return ViewHolder(itemView)
    }

    override fun getItemCount(): Int {
        return transportList.size
    }

    override fun onBindViewHolder(holder: ViewHolder, position: Int) {
        val holderView = holder.itemView
        val category = holderView.findViewById<TextView>(R.id.transport_category)
        category.text = transportList[position].category
        val recycler = holderView.findViewById<RecyclerView>(R.id.transport_category_recycler)
        val adapter = TransportLocationsAdapter()
        recycler.adapter = adapter
        recycler.layoutManager = LinearLayoutManager(holderView.context)
        adapter.setData(transportList[position].transportLocations)
    }

    public fun setData(data: List<HotelTransport>) {
        transportList = data
        notifyDataSetChanged()
    }
}