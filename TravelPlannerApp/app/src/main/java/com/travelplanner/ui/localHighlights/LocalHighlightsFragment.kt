package com.travelplanner.ui.localHighlights

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
import com.travelplanner.ui.hotel.HotelAdapter

class LocalHighlightsFragment : Fragment() {

    lateinit var viewModel: LocalHighlightsViewModel

    override fun onCreateView(inflater: LayoutInflater, container: ViewGroup?, savedInstanceState: Bundle?): View? {
        val v = inflater.inflate(R.layout.fragment_local_highlights, container, false)
        viewModel =
                ViewModelProvider(this).get(LocalHighlightsViewModel::class.java)
        activity?.intent?.getStringExtra(EXTRA_TRAVEL_ID)?.let {
            viewModel.setTravelId(it)
        }
        val recycler = v.findViewById<RecyclerView>(R.id.local_highlights_recycler)
        val adapter = LocalHighlightsAdapter()
        recycler.adapter = adapter
        recycler.layoutManager = LinearLayoutManager(context)
        viewModel.localHighlights.observe(viewLifecycleOwner, Observer {
            adapter.setData(it)
        })
        return v
    }

    companion object {
        val EXTRA_TRAVEL_ID = "travel_id"
    }
}