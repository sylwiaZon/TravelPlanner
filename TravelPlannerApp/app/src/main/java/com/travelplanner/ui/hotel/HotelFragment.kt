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

class HotelFragment : Fragment() {

    lateinit var viewModel: HotelViewModel

    override fun onCreateView(inflater: LayoutInflater, container: ViewGroup?, savedInstanceState: Bundle?): View? {
        val v = inflater.inflate(R.layout.fragment_hotel, container, false)
        viewModel =
                ViewModelProvider(this).get(HotelViewModel::class.java)
        activity?.intent?.getStringExtra(EXTRA_TRAVEL_ID)?.let {
            viewModel.setTravelId(it)
        }
        val recycler = v.findViewById<RecyclerView>(R.id.hotel_recycler)
        val name = v.findViewById<TextView>(R.id.hotel_name)
        val adapter = HotelAdapter()
        recycler.adapter = adapter
        recycler.layoutManager = LinearLayoutManager(context)
        viewModel.hotel.observe(viewLifecycleOwner, Observer {
            adapter.setData(it.transport)
            name.text = it.hotel.name
        })
        return v
    }

    companion object{
        val EXTRA_TRAVEL_ID = "travel_id"
    }
}