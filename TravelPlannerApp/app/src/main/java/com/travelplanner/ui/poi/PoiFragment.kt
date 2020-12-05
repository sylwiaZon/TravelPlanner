package com.travelplanner.ui.poi

import android.os.Bundle
import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import android.widget.LinearLayout
import android.widget.TextView
import androidx.fragment.app.Fragment
import androidx.recyclerview.widget.LinearLayoutManager
import androidx.recyclerview.widget.RecyclerView
import com.travelplanner.R
import com.travelplanner.models.Poi

class PoiFragment : Fragment(){

    override fun onCreateView(inflater: LayoutInflater, container: ViewGroup?, savedInstanceState: Bundle?): View? {
        val v = inflater.inflate(R.layout.fragment_poi, container, false)
        var poi: Poi? = activity?.intent?.getParcelableExtra(EXTRA_POI)
        val title = v.findViewById<TextView>(R.id.poi_title)
        title.text = poi?.name
        val description = v.findViewById<TextView>(R.id.poi_description)
        description.text = poi?.intro
        val bookingInfo = v.findViewById<LinearLayout>(R.id.poi_booking_info)
        if(poi?.price == "") bookingInfo.visibility = View.GONE
        else {
            val price = v.findViewById<TextView>(R.id.poi_price)
            val vendor = v.findViewById<TextView>(R.id.poi_vendor)
            price.text = poi?.price
            vendor.text = poi?.vendorUrl
        }
        val recycler = v.findViewById<RecyclerView>(R.id.poi_recycler)
        val adapter = PoiAdaper()
        recycler.adapter = adapter
        recycler.layoutManager = LinearLayoutManager(context)
        return v
    }

    companion object{
        val EXTRA_POI = "poi"
    }
}