package com.travelplanner.ui.hotel

import android.os.Bundle
import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import android.widget.TextView
import androidx.fragment.app.Fragment
import androidx.lifecycle.Observer
import androidx.lifecycle.ViewModelProvider
import androidx.recyclerview.widget.LinearLayoutManager
import androidx.recyclerview.widget.RecyclerView
import com.travelplanner.R
import com.travelplanner.ui.dayPlan.DayPlanAdapter

class  HotelFragment : Fragment() {

    lateinit var viewModel: HotelViewModel

    override fun onCreateView(inflater: LayoutInflater, container: ViewGroup?, savedInstanceState: Bundle?): View? {
        val v = inflater.inflate(R.layout.fragment_hotel, container, false)
        viewModel =
                ViewModelProvider(this).get(HotelViewModel::class.java)
        val travelId = activity?.intent?.getStringExtra(EXTRA_TRAVEL_ID)
        viewModel.setTravelId(travelId!!)
        val cityName = activity?.intent?.getStringExtra(EXTRA_TRAVEL_ID)
        val recycler = v.findViewById<RecyclerView>(R.id.hotel_recycler)
        val name = v.findViewById<TextView>(R.id.hotel_name)
        val adapter = HotelAdapter()
        recycler.adapter = adapter
        recycler.layoutManager = LinearLayoutManager(context)

        val noHotel = v.findViewById<RecyclerView>(R.id.no_saved_hotel)
        val hotelAdded = v.findViewById<RecyclerView>(R.id.hotel_added)
        val hotelSearchButton = v.findViewById<RecyclerView>(R.id.to_see_button)
        hotelSearchButton.setOnClickListener {
             context?.showSearchHotelDialog(cityName!!){
                viewModel.addHotel(it, travelId)
             }
        }
        hotelAdded.visibility = View.GONE
        viewModel.hotel.observe(viewLifecycleOwner, Observer {
            if(it != null){
                adapter.setData(it.transport)
                name.text = it.hotel.name
                hotelAdded.visibility = View.VISIBLE
                noHotel.visibility = View.GONE
            }
        })
        return v
    }

    companion object{
        val EXTRA_TRAVEL_ID = "travel_id"
        val EXTRA_CITY_NAME = "city_name"
    }
}