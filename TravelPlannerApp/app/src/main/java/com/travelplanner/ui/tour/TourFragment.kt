package com.travelplanner.ui.tour

import android.content.Intent
import android.net.Uri
import android.os.Bundle
import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import androidx.core.content.ContextCompat
import androidx.fragment.app.Fragment
import androidx.lifecycle.Observer
import androidx.lifecycle.ViewModelProvider
import androidx.recyclerview.widget.LinearLayoutManager
import androidx.recyclerview.widget.RecyclerView
import com.travelplanner.R
import com.travelplanner.ui.localHighlights.LocalHighlightsAdapter
import com.travelplanner.ui.localHighlights.LocalHighlightsViewModel

class TourFragment : Fragment() {

    lateinit var viewModel: TourViewModel

    override fun onCreateView(inflater: LayoutInflater, container: ViewGroup?, savedInstanceState: Bundle?): View? {
        val v = inflater.inflate(R.layout.fragment_tour, container, false)
        viewModel =
                ViewModelProvider(this).get(TourViewModel::class.java)
        activity?.intent?.getStringExtra(EXTRA_TRAVEL_ID)?.let {
            viewModel.setTravelId(it)
        }
        val recycler = v.findViewById<RecyclerView>(R.id.tours_recycler)
        val adapter = TourAdapter(){
            val browserIntent = Intent(Intent.ACTION_VIEW, Uri.parse(it))
            startActivity(browserIntent)
        }
        recycler.adapter = adapter
        recycler.layoutManager = LinearLayoutManager(context)
        viewModel.tours.observe(viewLifecycleOwner, Observer {
            adapter.setData(it)
        })
        return v
    }

    companion object {
        val EXTRA_TRAVEL_ID = "travel_id"
    }
}